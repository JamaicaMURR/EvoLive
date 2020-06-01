using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MasterScript : MonoBehaviour
{
    static System.Random rand = new System.Random();

    private List<GameObject> masterList;
    private Statistics st;
    private NeoOptions nop;
    private MapMaster mm;

    public GameObject cam;

    public float speed = 1;
    public float speedCap = 10;
    public float warpSpeed = 20;
    public int increaseEvery = 15;

    public int opFrHigh = 35;
    public int opFrLow = 25;
    public int sensivity = 100;

    private int mlIterator = 0;
    private int millisecondsForFrame = 33;
    private double remMutF = 0;
    private double remResMutF = 0;

    private bool reset = false;
    private bool cycleEnded = true;
    private bool isSpawnerenabled = true;
    private bool mutageddon = false;
    private bool stabiliddon = false;
    private bool recoloring = false;
    private bool recolorcycle = false;
    private bool paused = false;

    public MessageShower ms;

    private DateTime begMoment;
    private DateTime startMoment;

    Statizer s;

    void Awake()
    {
        s = new Statizer();

        st = GetComponent<Statistics>();
        nop = GetComponent<NeoOptions>();
        mm = GetComponent<MapMaster>();

        masterList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Cell"));

        begMoment = new DateTime(DateTime.Now.Ticks);
    }

    void Update()
    {
        ButtonsControl();

        if(!paused)
        {
            if(cycleEnded) // Cycle starter
            {
                if(recoloring)
                {
                    if(recolorcycle)
                    {
                        recolorcycle = false;
                        recoloring = false;
                    }
                    else
                    {
                        recolorcycle = true;
                        st.cycles--;
                    }
                }

                mlIterator = 0;

                masterList = mm.GetAll();
                masterList.TrimExcess();

                if(masterList.Count == 0)
                {
                    if(isSpawnerenabled)
                    {
                        masterList.Add(GetComponent<MasterSpawner>().Spawn());
                        startMoment = new DateTime(DateTime.Now.Ticks);
                    }

                    st.Wipe();

                    reset = false;
                }

                st.energyTotal = 0;
                st.alive = 0;
                st.shortestgnm = int.MaxValue;
                st.longestgnm = 0;

                st.cycles++;

                List<GameObject> shuffledMasterList = new List<GameObject>();

                while(masterList.Count > 0)
                {
                    int selectedNumber = rand.Next(masterList.Count);

                    GameObject chosenOne = masterList[selectedNumber];

                    st.energyTotal += chosenOne.GetComponent<CellVars>().Energy;

                    st.alive++;

                    int gl = chosenOne.GetComponent<GNM>().Length;

                    if(gl < st.shortestgnm)
                        st.shortestgnm = gl;

                    if(gl > st.longestgnm)
                        st.longestgnm = gl;

                    shuffledMasterList.Add(chosenOne);

                    masterList.RemoveAt(selectedNumber);
                }

                masterList = shuffledMasterList;
                masterList.TrimExcess();

                cycleEnded = false;
            }

            TimeSpan ts = DateTime.Now - begMoment;

            int iters = 0;

            if(cam.activeSelf && nop.effects)
                speedCap = st.alive / 5f + 1;
            else
                speedCap = int.MaxValue;

            while(ts.TotalMilliseconds < millisecondsForFrame && iters < speedCap)
            {
                if(mlIterator < masterList.Count)
                {
                    GameObject selectedOne = masterList[mlIterator];

                    if(!recolorcycle)
                    {
                        if(!reset)
                        {
                            if(mm.IsAlive(selectedOne))
                                selectedOne.GetComponent<GenomeReader>().MasterHand();
                        }
                        else
                            selectedOne.GetComponent<NeoDeathCounter>().InstantDeath();
                    }
                    else
                        selectedOne.GetComponent<GenColorer>().ReColor();

                    mlIterator++;
                }
                else
                {
                    cycleEnded = true;
                    break;
                }

                iters++;

                ts = DateTime.Now - begMoment;
            }

            s.Add(iters / Time.deltaTime);
            speed = s.V;

            begMoment = new DateTime(DateTime.Now.Ticks);
        }

    }

    //=============================================================================================================================

    private void ButtonsControl()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            millisecondsForFrame = 80;
            ms.ShowMessage("12 FPS Cap");
            s.Reset();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            millisecondsForFrame = 40;
            ms.ShowMessage("25 FPS Cap");
            s.Reset();
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            millisecondsForFrame = 33;
            ms.ShowMessage("30 FPS Cap");
            s.Reset();
        }

        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            millisecondsForFrame = 25;
            ms.ShowMessage("40 FPS Cap");
            s.Reset();
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            TimeSpan ts = DateTime.Now.Subtract(startMoment);

            string hours, minutes, seconds;

            if(ts.Hours / 10 > 0)
                hours = ts.Hours.ToString();
            else
                hours = "0" + ts.Hours;

            if(ts.Minutes / 10 > 0)
                minutes = ts.Minutes.ToString();
            else
                minutes = "0" + ts.Minutes;

            if(ts.Seconds / 10 > 0)
                seconds = ts.Seconds.ToString();
            else
                seconds = "0" + ts.Seconds;

            ms.ShowMessage("Simulation time: " + ts.Days + " d " + hours + " h " + minutes + " m " + seconds + " s");

        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            reset = true;
            ms.ShowMessage("Reset");
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            isSpawnerenabled = !isSpawnerenabled;

            if(isSpawnerenabled)
                ms.ShowMessage("Spawner On");
            else
                ms.ShowMessage("Spawner Off");
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            cam.SetActive(!cam.activeSelf);

            if(cam.activeSelf)
            {
                ms.ShowMessage("Graphics On");
                nop.effects = true;
            }
            else
            {
                ms.ShowMessage("Graphics Off");
                nop.effects = false;
            }

            s.Reset();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            nop.effects = !nop.effects;

            if(nop.effects)
            {
                ms.ShowMessage("Effects On");
                nop.effects = true;
            }
            else
            {
                ms.ShowMessage("Effects Off");
                nop.effects = false;
            }

            s.Reset();
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            if(!nop.shiftEffects && nop.effects)
            {
                nop.shiftEffects = true;
                ms.ShowMessage("Shift Effects On");
            }
            else if(nop.shiftEffects && nop.effects)
            {
                nop.shiftEffects = false;
                ms.ShowMessage("Shift Effects Off");
            }

            s.Reset();
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            nop.specialSpawn = !nop.specialSpawn;

            if(nop.specialSpawn)
            {
                ms.ShowMessage("Fast Spawn On");
            }
            else
            {
                ms.ShowMessage("Fast Spawn Off");
            }
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            if(!stabiliddon)
                if(!mutageddon)
                {
                    remMutF = nop.codonMutFreq;
                    remResMutF = nop.resizeMutFreq;
                    nop.codonMutFreq = 1;
                    nop.resizeMutFreq = 1;
                    ms.ShowMessage("Mutageddon On");
                    mutageddon = true;
                }
                else
                {
                    nop.codonMutFreq = remMutF;
                    nop.resizeMutFreq = remResMutF;
                    ms.ShowMessage("Mutageddon Off");
                    mutageddon = false;
                }
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            if(!mutageddon)
                if(!stabiliddon)
                {
                    remMutF = nop.codonMutFreq;
                    remResMutF = nop.resizeMutFreq;
                    nop.codonMutFreq = 0;
                    nop.resizeMutFreq = 0;
                    ms.ShowMessage("Stabiliddon On");
                    stabiliddon = true;
                }
                else
                {
                    nop.codonMutFreq = remMutF;
                    nop.resizeMutFreq = remResMutF;
                    ms.ShowMessage("Stabiliddon Off");
                    stabiliddon = false;
                }
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            if(!recolorcycle)
            {
                nop.colorScheme = 0;
                recoloring = true;
                ms.ShowMessage("Color Scheme 1");
            }
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            if(!recolorcycle)
            {
                nop.colorScheme = 1;
                recoloring = true;
                ms.ShowMessage("Color Scheme 2");
            }
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            if(!recolorcycle)
            {
                nop.colorScheme = 2;
                recoloring = true;
                ms.ShowMessage("Color Scheme 3");
            }
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            if(nop.speedFormat == 0)
                nop.speedFormat = 1;
            else
                nop.speedFormat = 0;

            ms.ShowMessage("Speed Format Changed");
        }

        if(Input.GetKeyDown(KeyCode.Y))
        {
            if(st.shortestgnm == st.longestgnm)
                ms.ShowMessage("Genom Length " + st.shortestgnm);
            else
                ms.ShowMessage("Genom length " + st.shortestgnm + " / " + st.longestgnm);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            paused = !paused;

            if(paused)
                ms.ShowMessage("Pause");
            else
                ms.ShowMessage("Resume");
        }
    }
}

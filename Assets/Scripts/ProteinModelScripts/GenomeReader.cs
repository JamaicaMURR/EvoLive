using UnityEngine;
using System.Collections.Generic;

public class GenomeReader : MonoBehaviour
{
    public static Protein[] pkeys = new Protein[] { new FreeConsumon(), new Spliton(), new RightRotaton(), new LeftRotaton(), new Movon(),
    new VoidConsumon() /*5*/, new CellConsumon(), new Injecton(), new Rebirthon(), new Pushon(), new Swapon() /*10*/, new Killon(), new Suicidon(),
    new Explodon(), new Equalon(), new TransMovon() /*15*/, new TransInjecton(), new MHungeron(), new EcKillon(), new Sprayon(), new Navigon0() /*20*/,
    new Navigon1(), new Navigon2(), new Navigon3(), new Navigon4(), new Navigon5() /*25*/, new AssGearon(), new KissGearon(), new Energivon(),
    new Accumuton(), new NavigonB() /*30*/, new InjectIngibiton(), new FreeconsumExplodon(), new SplitDeenergon(), new MoveAcceleron(),
    new PBomberon() /*35*/, new TransSwapon(), new SplitPrion(), new OldEnergivon(), new YoungEnergivon(), new Backwardon() /*40*/,
    new HighEnBomberon(), new YoungRestarton(), new OldRestarton(), new OnceRestarton(), new OnceDeRestarton() /*45*/, new LowEnRestarton(),
    new HighEnRestarton(), new Restarton(), new ShiftIngibiton(), new DoubleShifton() /*50*/, new YoungEGFabricaton(), new Fuson(), new Spamon(),
    new Doubleton(), new MovFabricaton() /*55*/, new LowEnergivon(), new FullAheadon(), new TransRotaton(), new EqBomberon(),
    new NavRestarton0()  /*60*/, new NavRestarton1(), new NavRestarton2(), new NavRestarton3(), new NavRestarton4(), new NavRestarton5() /*65*/,
    new NavRestartonB(), new NavRestartonAB(), new InjSPrion(), new FusFabricaton(), new FreConUtiliton() /*70*/, new InjSPrionUtiliton(),
    new SuiNExplUtiliton(), new FCExpUtiliton(), new HEBomUtiliton(), new Maklayon() /*75*/, new FCPlaguon(), new MaklUtiliton(), new FCPlagStarton(),
    new PopCornon(), new LightSpeedon() /*80*/, new FCFabricaton(), new Restarton12(), new Restarton6B(), new SmoothAgeRestarton(),
    new SmoothAgeDeRestarton() /*85*/, new TransRestarton12(), new TransBetaRestarton12(), new KilOldExTranson(), new HighEnSPRegulon(),
    new LKillon18() /*90*/, new InjDeathon(), new HalfShifton(), new TShifton(), new Nothingon(), new ImidSprayon() /*95*/, new AlphaHolyGrailon(),
    new BetaHolyGrailon(), new GammaHolyGrailon(), new HighEnDeathon(), new SPrPrion() /*100*/, new JCeenon(), new JCActivon(), new TransNavigonB(),
    new JCFabricaton(), new FCDeshifton() /*105*/, new SurInjAHGon(), new LeDeplaguon(), new BackBudon(), new AnothDoubleton(),
    new ImidfromFCFuson() /*110*/, new R2Rotaton(), new L2Rotaton(), new PFabricaton(), new KSurVCon(), new SurMovon() /*115*/, new Conservon(),
    new ForBudon(), new GForBudon(), new InjRevoluton(), new FcWVcoon() /*120*/, new FC6Restarton(), new BackGciBudon(), new SpaceConsumon(),
    new PExchangon(), new SCSinkon() /*125*/, new Shuffleton(), new SplitonStealon(), new FCWaston(), new HeritShifton(), new MASuron() /*130*/,
    new HEnTMovon(), new SurRoton(), new KSMon(), new InjExpon(), new FSpliton() /*135*/, new FastBackRoton(), new AltMovon(), new MAFon(),
    new FCImidSprayon()};

    NeoDeathCounter ndc;
    GNM gnm;
    CellVars cv;
    NeoOptions nop;

    //=============================================================================================================================

    void Awake()
    {
        nop = GameObject.Find("Master").GetComponent<NeoOptions>();

        ndc = GetComponent<NeoDeathCounter>();
        gnm = GetComponent<GNM>();
        cv = GetComponent<CellVars>();
    }

    //=============================================================================================================================

    public void MasterHand()
    {
        int i = GNM.Decode(gnm.GenNShift, pkeys.Length);

        if(cv.Energy >= nop.proteinCost && cv.lifeResource > 0)
        {
            cv.Energy -= nop.proteinCost;
            cv.lifeResource -= nop.proteinCost;
            cv.proteins[pkeys[i].PCode]++;

            pkeys[i].ReactIn(gameObject);

            ndc.DeathControl();
        }
        else
        {
            ndc.InstantDeath();
        }
    }
}

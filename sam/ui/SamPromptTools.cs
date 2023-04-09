using Microsoft.VisualBasic;
using NAudio.CoreAudioApi;
using NAudio.SoundFont;
using sam.gpt;
using sam.helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sam.ui
{
    public partial class SamPromptTools : DockContent
    {
        internal TreeViewBuilder treeViewBuilder { get; private set; }
        public List<string> kategoriat { get; private set; }
        public DockPanel dockPanelSAM { get; private set; }
        public SAM sAM { get; private set; }
        public List<string> categories { get; private set; }

        public SamPromptTools(DockPanel dockPanelSAM, SAM sAM)
        {
            InitializeComponent();
            this.dockPanelSAM = dockPanelSAM;
            this.sAM = sAM;
        }

        private void SamPromptTools_Load(object sender, EventArgs e)
        {
            treeViewBuilder = new TreeViewBuilder(promptTree);

            // Luo kategoriat

            kategoriat = new List<string> {
        "Ohjelmistokehitys",
        "Taloushallinto",
        "Laki",
        "Henkilöstöhallinto",
        "Terveydenhuolto",
        "Suunnittelu ja media",
        "Koulutus",
        "Kielet ja käännökset",
        "Tietojen analysointi",
        "Asiakastuki",
        "Sisällöntuotanto",
        "Robotiikka ja automaatio",
        "Markkinointi",
        "Myynti",
        "Toiminnanohjaus",
        "Toimitusketjun hallinta",
        "Tietotekniikka",
        "Projektinhallinta",
        "Laadunvarmistus",
        "Tutkimus ja kehitys",
        "Liiketoimintastrategia",
        "Johtajuus ja hallinto",
        "Ympäristökestävyys",
        "Sosiaalinen vastuu ja etiikka",
        "Matkailu ja hotelliala",
        "Ravintola- ja elintarvikeala",
        "Logistiikka ja kuljetus",
        "Energia ja ympäristö",
        "Rakentaminen ja kiinteistöala",
        "Muotoilu ja taide",
        "Musiikki ja viihde",
        "Urheilu ja kuntoilu",
        "Turvallisuus ja valvonta",
        "Tekninen tuki ja huolto",
        "Sosiaalipalvelut ja terapia",
        "Psykologia ja mielenterveys",
        "Kulttuuri ja historia",
        "Politiikka ja hallinto",
        "Kansainväliset suhteet",
        "Konsultointi ja neuvonta",
        "Verkkokauppa ja e-commerce",
        "Graafinen suunnittelu",
        "Valokuvaus ja videokuvaus",
        "Sosiaalinen media ja viestintä",
        "Teknologia ja innovaatiot",
        "Teollisuus ja valmistus",
        "Maatalous ja metsätalous",
        "Eläintenhoito ja -kasvatus",
        "Lastenhoito ja kasvatus",
        "Ikääntyneiden hoito ja palvelut",
        "Kielitaito ja kulttuurinväliset taidot",
        "Matematiikka ja tilastotiede",
        "Fysiikka ja kemia",
        "Biologia ja lääketiede"
    };


            // Add top-level categories
            foreach (var category in kategoriat)
            {
                treeViewBuilder.AddTopLevelCategory(category, Properties.Resources._2890580_ai_artificial_intelligence_brain_electronics_robotics_icon_24);
            }

            // Lisää alakategoriat Ohjelmistokehitys
            AddSubCategory("Ohjelmistokehitys", "Miten priorisoit vianetsintäponnisteluja monimutkaisessa ohjelmistoprojektissa?", "Luo opas vianetsintäponnistelujen priorisoinnista monimutkaisessa ohjelmistoprojektissa, keskittyen avainasioihin kuten parametri1, parametri2 ja parametri3. Selitä jokaisen näkökohdan tärkeys ja anna toimintasuunnitelma ohjelmistokehittäjille, jotta he voivat parantaa vianetsintäprosessiaan tehokkaasti.");
            AddSubCategory("Ohjelmistokehitys", "Mitkä ovat parhaat käytännöt koodiarvioinneille?", "Luo kattava opas parhaista käytännöistä koodiarvioinneille, mukaan lukien vinkkejä rakentavan palautteen antamiseen, yleisten koodausvirheiden tunnistamiseen ja koodin laadun ja yhdenmukaisuuden varmistamiseen.");
            AddSubCategory("Ohjelmistokehitys", "Miten optimoit tietokannan suorituskykyä?", "Kirjoita artikkeli tärkeimmistä strategioista tietokannan suorituskyvyn optimoimiseksi, mukaan lukien indeksointi, kyselyoptimointi ja tietokannan suunnittelun parhaat käytännöt.");
            AddSubCategory("Ohjelmistokehitys", "Mitkä ovat yleisimmät ohjelmistokehitysmenetelmät?", "Luo opas, joka selittää yleisimmät ohjelmistokehitysmenetelmät, mukaan lukien Agile, Waterfall ja Scrum. Keskustele kunkin menetelmän eduista ja haitoista ja anna esimerkkejä siitä, milloin kukin menetelmä on sopivin.");
            AddSubCategory("Ohjelmistokehitys", "Miten varmistat ohjelmiston turvallisuuden?", "Kirjoita artikkeli tärkeimmistä strategioista ohjelmiston turvallisuuden varmistamiseksi, mukaan lukien turvalliset koodauskäytännöt, haavoittuvuustestaus ja uhkamallinnus.");
            AddSubCategory("Ohjelmistokehitys", "Mitkä ovat parhaat työkalut ohjelmistokehitykseen?", "Luo lista parhaista työkaluista ohjelmistokehitykseen, mukaan lukien IDE:t, versionhallintajärjestelmät ja testauskehykset. Anna lyhyt yleiskatsaus jokaisesta työkalusta ja selitä, miksi se on hyödyllinen ohjelmistokehittäjille.");
            AddSubCategory("Ohjelmistokehitys", "Miten hallitset ohjelmistoriippuvuuksia?", "Kirjoita artikkeli parhaista käytännöistä ohjelmistoriippuvuuksien hallitsemiseksi, mukaan lukien konfliktien tunnistaminen ja ratkaiseminen, versionhallinnan käsittely ja yhteensopivuuden varmistaminen.");
            AddSubCategory("Ohjelmistokehitys", "Mitkä ovat ohjelmistoarkkitehtuurin keskeiset periaatteet?", "Luo opas, joka selittää ohjelmistoarkkitehtuurin keskeiset periaatteet, mukaan lukien modulaarisuus, skaalautuvuus ja ylläpidettävyys. Anna esimerkkejä siitä, miten näitä periaatteita voidaan soveltaa todellisissa ohjelmistokehitysprojekteissa.");
            AddSubCategory("Ohjelmistokehitys", "Miten toteutat jatkuvan integroinnin ja käyttöönoton?", "Kirjoita artikkeli tärkeimmistä strategioista jatkuvan integroinnin ja käyttöönoton toteuttamiseksi, mukaan lukien testaus- ja käyttöönottoprosessien automatisointi, rakennustyökalujen käyttö ja koodin laadun varmistaminen.");
            AddSubCategory("Ohjelmistokehitys", "Mitkä ovat parhaat käytännöt ohjelmistodokumentoinnille?", "Luo opas parhaista käytännöistä ohjelmistodokumentoinnille, mukaan lukien selkeän ja tiiviin dokumentoinnin kirjoittaminen, dokumentoinnin tehokas järjestäminen ja dokumentoinnin ajantasaisuuden varmistaminen.");
            AddSubCategory("Ohjelmistokehitys", "Miten hallitset ohjelmistoprojektin aikatauluja?", "Kirjoita artikkeli parhaista käytännöistä ohjelmistoprojektin aikataulujen hallitsemiseksi, mukaan lukien projektiaikataulujen tarkka arviointi, riskien tunnistaminen ja lieventäminen sekä projektin edistymisen tehokas viestintä sidosryhmille.");

            // Lisää alakategorioita taloushallinnolle
            AddSubCategory("Taloushallinto", "Mitkä ovat tärkeimmät taloudelliset suhdeluvut liiketoiminnan analyysissä?", "Luo opas, joka selittää tärkeimmät taloudelliset suhdeluvut liiketoiminnan analyysissä, mukaan lukien kannattavuussuhteet, likviditeettisuhteet ja maksuvalmiussuhteet. Anna esimerkkejä siitä, miten näitä suhdelukuja voidaan käyttää yrityksen taloudellisen terveyden arvioimiseen.");
            AddSubCategory("Taloushallinto", "Miten luodaan talousarvio yritykselle?", "Kirjoita artikkeli parhaista käytännöistä talousarvion luomiseen yritykselle, mukaan lukien kuinka ennustaa tuloja ja kuluja, kuinka tunnistaa ja priorisoida budjettikohteita ja kuinka seurata ja säätää budjettia ajan myötä.");
            AddSubCategory("Taloushallinto", "Mitkä ovat erilaiset taloudelliset raportit?", "Luo opas, joka selittää erilaiset taloudelliset raportit, mukaan lukien tase, tuloslaskelma ja rahavirtalaskelma. Keskustele kunkin raportin tarkoituksesta ja anna esimerkkejä siitä, miten niitä voidaan käyttää yrityksen taloudellisen suorituskyvyn arvioimiseen.");
            AddSubCategory("Taloushallinto", "Miten arvioidaan sijoitusmahdollisuuksia?", "Kirjoita artikkeli keskeisistä strategioista sijoitusmahdollisuuksien arvioimiseksi, mukaan lukien kuinka laskea sijoitetun pääoman tuotto, kuinka arvioida riskiä ja kuinka tunnistaa ja analysoida markkinatrendejä.");
            AddSubCategory("Taloushallinto", "Mitkä ovat parhaat käytännöt taloudellisessa riskienhallinnassa?", "Luo opas parhaista käytännöistä taloudellisessa riskienhallinnassa, mukaan lukien kuinka tunnistaa ja arvioida taloudellisia riskejä, kuinka kehittää riskienhallintastrategioita ja kuinka seurata ja säätää riskienhallintasuunnitelmia ajan myötä.");
            AddSubCategory("Taloushallinto", "Miten luodaan talousennuste yritykselle?", "Kirjoita artikkeli parhaista käytännöistä talousennusteen luomiseen yritykselle, mukaan lukien kuinka käyttää historiallista dataa ja markkinatrendejä ennusteiden tekemiseen, kuinka tunnistaa ja priorisoida ennustekohteita ja kuinka seurata ja säätää ennustetta ajan myötä.");
            AddSubCategory("Taloushallinto", "Mitkä ovat tärkeimmät taloudelliset mittarit liiketoiminnan analyysissä?", "Luo opas, joka selittää tärkeimmät taloudelliset mittarit liiketoiminnan analyysissä, mukaan lukien liikevaihdon kasvu, voittomarginaali ja sijoitetun pääoman tuotto. Anna esimerkkejä siitä, miten näitä mittareita voidaan käyttää yrityksen taloudellisen suorituskyvyn arvioimiseen.");
            AddSubCategory("Taloushallinto", "Miten hallitaan kassavirtaa yrityksessä?", "Kirjoita artikkeli parhaista käytännöistä kassavirran hallintaan yrityksessä, mukaan lukien kuinka ennustaa kassavirtaa, kuinka tunnistaa ja priorisoida kassavirtakohteita ja kuinka seurata ja säätää kassavirtaa ajan myötä.");
            AddSubCategory("Taloushallinto", "Mitkä ovat parhaat käytännöt taloudellisessa raportoinnissa?", "Luo opas parhaista käytännöistä taloudellisessa raportoinnissa, mukaan lukien kuinka valmistella taloudellisia raportteja, kuinka varmistaa tarkkuus ja täydellisyys ja kuinka viestiä taloudellista tietoa tehokkaasti sidosryhmille.");
            AddSubCategory("Taloushallinto", "Miten luodaan talousmalli yritykselle?", "Kirjoita artikkeli parhaista käytännöistä talousmallin luomiseen yritykselle, mukaan lukien kuinka käyttää historiallista dataa ja markkinatrendejä ennusteiden tekemiseen, kuinka tunnistaa ja priorisoida mallikohteita ja kuinka seurata ja säätää mallia ajan myötä.");

            // Lisää alakategorioita lakiasioille
            AddSubCategory("Laki", "Mitkä ovat erilaiset oikeudelliset sopimukset?", "Luo opas, joka selittää erilaiset oikeudelliset sopimukset, mukaan lukien työsopimukset, salassapitosopimukset ja vuokrasopimukset. Keskustele kunkin sopimuksen tarkoituksesta ja anna esimerkkejä siitä, milloin niitä voidaan käyttää.");
            AddSubCategory("Laki", "Mitkä ovat parhaat käytännöt immateriaalioikeuksien suojaamiseen?", "Kirjoita artikkeli parhaista käytännöistä immateriaalioikeuksien suojaamiseen, mukaan lukien patentit, tavaramerkit ja tekijänoikeudet. Keskustele immateriaalioikeuksien suojaamiseen liittyvistä laillisista vaatimuksista ja anna esimerkkejä siitä, kuinka niitä voidaan soveltaa käytännössä.");
            AddSubCategory("Laki", "Miten navigoidaan yrityksen lakienmukaisuudessa?", "Luo opas siitä, kuinka navigoidaan yrityksen lakienmukaisuudessa, mukaan lukien relevanttien lakien ja määräysten ymmärtäminen ja noudattaminen, politiikkojen ja menettelyjen luominen ja henkilöstön kouluttaminen lakienmukaisuusvaatimuksista.");
            AddSubCategory("Laki", "Mitkä ovat erilaiset yritysrakenteet ja niiden oikeudelliset vaikutukset?", "Luo opas, joka selittää erilaiset yritysrakenteet, mukaan lukien toiminimi, avoin yhtiö, kommandiittiyhtiö ja osakeyhtiö. Keskustele kunkin rakenteen oikeudellisista vaikutuksista ja anna ohjeita siitä, kuinka valita sopiva rakenne yritykselle.");
            AddSubCategory("Lakiasiat", "Mitkä ovat tärkeimmät työlainsäädännön asiat, jotka jokaisen yrityksen omistajan tulisi tietää?", "Kirjoita artikkeli tärkeimmistä työlainsäädännön asioista, joista jokaisen yrityksen omistajan tulisi olla tietoinen, mukaan lukien minimipalkka, ylityö, syrjintäkiellot ja työpaikan turvallisuuslait. Anna esimerkkejä siitä, kuinka nämä lait voivat vaikuttaa yritykseen ja kuinka niitä noudatetaan.");
            AddSubCategory("Laki", "Mitkä ovat tärkeimmät oikeudelliset näkökohdat uuden yrityksen perustamisessa?", "Luo lista tärkeimmistä oikeudellisista näkökohdista yrittäjille, jotka perustavat uuden yrityksen, kattaen aiheet kuten yrityksen rekisteröinti, immateriaalioikeuksien suojaaminen, sopimukset ja vastuu. Anna käytännön neuvoja ja ohjeita uusille yrittäjille varmistaakseen, että he noudattavat kaikkia relevantteja lakeja ja määräyksiä.");

            // Lisää alakategorioita henkilöstöhallinnolle
            AddSubCategory("Henkilöstöhallinto", "Miten suoritetaan tehokkaita suoritusarviointeja?", "Kirjoita artikkeli tehokkaiden suoritusarviointien suorittamisesta, mukaan lukien suoritus tavoitteiden asettaminen, rakentavan palautteen antaminen ja suoritusarviointien dokumentointi.");
            AddSubCategory("Henkilöstöhallinto", "Mitkä ovat parhaat käytännöt uusien työntekijöiden perehdyttämisessä?", "Luo opas parhaista käytännöistä uusien työntekijöiden perehdyttämisessä, mukaan lukien perehdyttämisohjelman luominen, selkeiden odotusten asettaminen ja uusien työntekijöiden integroiminen yrityskulttuuriin.");
            AddSubCategory("Henkilöstöhallinto", "Miten luodaan tehokas työntekijöiden kehittämisohjelma?", "Kirjoita artikkeli tehokkaan työntekijöiden kehittämisohjelman luomisesta, mukaan lukien työntekijöiden kehittämistarpeiden tunnistaminen, koulutusohjelmien suunnittelu ja työntekijöiden kehittämisen tehokkuuden mittaaminen.");
            AddSubCategory("Henkilöstöhallinto", "Miten suoritetaan tehokkaita työntekijöiden suoritusarviointeja?", "Kirjoita artikkeli parhaista käytännöistä työntekijöiden suoritusarviointien suorittamiseen, mukaan lukien kuinka asettaa selkeät suoritustavoitteet, kuinka antaa rakentavaa palautetta ja kuinka luoda toimintasuunnitelmia suorituskyvyn parantamiseksi.");

            // Lisää alakategorioita terveydenhuollolle
            AddSubCategory("Terveydenhuolto", "Mikä ovat parhaat käytännöt potilashoidossa?", "Luo opas parhaista käytännöistä potilashoidossa, mukaan lukien tehokas kommunikointi potilaiden kanssa, potilaiden odotusten hallinta ja potilaskeskeinen hoito.");
            AddSubCategory("Terveydenhuolto", "Kuinka varmistetaan potilasturvallisuus terveydenhuollossa?", "Kirjoita artikkeli siitä, kuinka varmistetaan potilasturvallisuus terveydenhuollossa, mukaan lukien riskien tunnistaminen ja lieventäminen, turvallisuusprotokollien käyttöönotto ja turvallisuuskulttuurin edistäminen työpaikalla.");
            AddSubCategory("Terveydenhuolto", "Mikä ovat parhaat käytännöt terveydenhuollon hallinnassa?", "Luo opas parhaista käytännöistä terveydenhuollon hallinnassa, mukaan lukien terveydenhuollon talouden hallinta, työnkulun optimointi ja pysyminen ajan tasalla terveydenhuollon säännöksistä.");
            AddSubCategory("Terveydenhuolto", "Mikä ovat tärkeimmät trendit ja haasteet terveydenhuoltoalalla?", "Kirjoita artikkeli tärkeimmistä trendeistä ja haasteista, joita terveydenhuoltoala kohtaa, mukaan lukien uudet teknologiat, muuttuvat säännökset ja kehittyvät potilastarpeet. Keskustele näiden trendien ja haasteiden vaikutuksista terveydenhuollon organisaatioille.");
            AddSubCategory("Terveydenhuolto", "Kuinka toteutetaan tehokkaita terveydenhuollon laadunparannushankkeita?", "Luo opas tehokkaiden laadunparannushankkeiden toteuttamisesta terveydenhuollon organisaatioissa, mukaan lukien kuinka tunnistaa parannusmahdollisuuksia, kuinka suunnitella parannushankkeita ja kuinka seurata ja arvioida hankkeiden tuloksia.");
            AddSubCategory("Terveydenhuolto", "Mikä ovat tärkeimmät trendit terveysteknologiassa?", "Luo yleiskatsaus tärkeimmistä terveysteknologian trendeistä, käsitellen aiheita kuten sähköiset potilastiedot, etälääketiede, tekoäly ja käyttöön soveltuvat laitteet. Anna käytännön esimerkkejä siitä, miten näitä teknologioita käytetään potilastulosten parantamiseen ja terveydenhuollon toimitusprosessien virtaviivaistamiseen.");

            // Lisää alakategorioita suunnittelulle ja mediassa
            AddSubCategory("Suunnittelu ja media", "Kuinka luoda tehokkaita visuaalisia suunnitelmia?", "Kirjoita artikkeli siitä, kuinka luoda tehokkaita visuaalisia suunnitelmia, mukaan lukien oikeiden värien, typografian ja asettelun valitseminen ja visuaalisten suunnitelmien optimointi eri medioille.");
            AddSubCategory("Suunnittelu ja media", "Mikä ovat parhaat käytännöt käyttäjäkokemuksen suunnittelussa?", "Luo opas parhaista käytännöistä käyttäjäkokemuksen suunnittelussa, mukaan lukien käyttäjätutkimuksen suorittaminen, käyttöliittymien suunnittelu ja suunnitelmien testaus ja iterointi käyttäjäpalautteen perusteella.");
            AddSubCategory("Suunnittelu ja media", "Kuinka luoda tehokkaita markkinointimateriaaleja?", "Kirjoita artikkeli siitä, kuinka luoda tehokkaita markkinointimateriaaleja, mukaan lukien markkinointikampanjoiden suunnittelu, vakuuttavan kopion luominen ja oikeiden markkinointikanavien valitseminen kohdeyleisöjen tavoittamiseksi.");
            AddSubCategory("Suunnittelu ja media", "Mikä ovat parhaat käytännöt tehokkaan graafisen suunnittelun luomiseen?", "Kirjoita artikkeli parhaista käytännöistä tehokkaan graafisen suunnittelun luomiseen, mukaan lukien kuinka käyttää väriä, typografiaa ja asettelua viestin välittämiseen ja tunteiden herättämiseen. Anna esimerkkejä tehokkaasta graafisesta suunnittelusta ja keskustele niiden periaatteista.");
            AddSubCategory("Suunnittelu ja media", "Kuinka luoda onnistunut sosiaalisen median markkinointikampanja?", "Luo opas parhaista käytännöistä onnistuneen sosiaalisen median markkinointikampanjan luomiseen, mukaan lukien kuinka asettaa tavoitteet, kuinka tunnistaa kohdeyleisöt ja kuinka kehittää ja jakaa osallistavaa sisältöä.");
            AddSubCategory("Suunnittelu ja media", "Mikä ovat graafisen suunnittelun keskeiset periaatteet?", "Luo opas graafisen suunnittelun keskeisistä periaatteista, käsitellen aiheita kuten typografia, väriteoria, kompositio ja visuaalinen hierarkia. Anna käytännön esimerkkejä ja neuvoja suunnittelijoille visuaalisesti houkuttelevien ja tehokkaiden suunnitelmien luomiseksi eri medioille.");

            // Lisää alakategorioita koulutukselle
            AddSubCategory("Koulutus", "Miten luoda tehokkaita oppitunteja?", "Kirjoita artikkeli tehokkaiden oppituntien suunnittelusta, mukaan lukien oppimistavoitteiden asettaminen, sopivien opetusmenetelmien valitseminen ja opiskelijoiden oppimistulosten arviointi.");
            AddSubCategory("Koulutus", "Mikä on paras käytäntö opiskelijoiden arvioinnissa?", "Luo opas parhaista käytännöistä opiskelijoiden arvioinnissa, mukaan lukien arviointityökalujen suunnittelu, arvostelu ja palautteen antaminen sekä arviointitiedon käyttäminen opetuksen suunnittelussa.");
            AddSubCategory("Koulutus", "Mitkä ovat koulutuksen keskeiset trendit ja haasteet?", "Kirjoita artikkeli koulutusalaa koskevista keskeisistä trendeistä ja haasteista, mukaan lukien uudet teknologiat, muuttuvat opiskelijatarpeet ja kehittyvät opetusmenetelmät. Keskustele näiden trendien ja haasteiden vaikutuksista koulutuslaitoksiin.");
            AddSubCategory("Koulutus", "Miten luoda tehokas verkkokoulutusohjelma?", "Luo opas parhaista käytännöistä tehokkaan verkkokoulutusohjelman luomiseen, mukaan lukien kuinka suunnitella osallistavia ja vuorovaikutteisia kursseja, kuinka arvioida oppimistuloksia ja kuinka luoda tukeva verkkokoulutusyhteisö.");
            AddSubCategory("Koulutus", "Miten suunnitella tehokas verkkokurssi?", "Luo opas tehokkaiden verkkokurssien suunnittelusta ja toteuttamisesta, käsitellen aiheita kuten opetusmuotojen suunnittelu, multimediakehitys ja arviointi. Tarjoa käytännön vinkkejä ja neuvoja opettajille, jotta he voivat luoda osallistavia ja tehokkaita verkkokursseja, jotka vastaavat oppijoiden tarpeita.");

            // Kirjoita "Kieli ja käännös",
            AddSubCategory("Kielet ja käännökset", "Mikä on paras käytäntö ammattimaisissa käännöspalveluissa?", "Kirjoita artikkeli parhaista käytännöistä ammattimaisissa käännöspalveluissa, mukaan lukien käännöshankkeiden hallinta, laadun ja tarkkuuden varmistaminen sekä luottamuksellisuuden ja turvallisuuden ylläpitäminen.");
            AddSubCategory("Kielet ja käännökset", "Miten toteuttaa tehokasta kulttuurienvälistä viestintää?", "Luo opas parhaista käytännöistä tehokkaassa kulttuurienvälisessä viestinnässä, mukaan lukien kulttuurierojen ymmärtäminen, viestintätapojen sopeuttaminen ja suhteen rakentaminen ja luottamuksen luominen eri kulttuureista tulevien ihmisten kanssa.");
            AddSubCategory("Kielet ja käännökset", "Mikä on paras käytäntö teknisten asiakirjojen kääntämisessä?", "Luo opas parhaista käytännöistä teknisten asiakirjojen kääntämisessä, käsitellen aiheita kuten terminologian hallinta, käännösmuistityökalut ja laadunvarmistus. Tarjoa käytännön vinkkejä ja neuvoja kääntäjille, jotta he voivat tuottaa tarkkoja ja tehokkaita teknisen sisällön käännöksiä.");

            // Lisää alakategorioita tietojen analysoinnille
            AddSubCategory("Tietojen analysointi", "Mitkä ovat tietojen analysoinnin keskeiset vaiheet?", "Luo opas tietojen analysoinnin keskeisistä vaiheista, käsitellen aiheita kuten tietojen kerääminen, puhdistus, analysointi ja visualisointi. Tarjoa käytännön esimerkkejä ja neuvoja tietoanalyytikoille, jotta he voivat tehokkaasti analysoida ja viestiä tietoja.");

            // Lisää alakategorioita asiakastuelle
            AddSubCategory("Asiakastuki", "Miten tarjota poikkeuksellista asiakaspalvelua?", "Luo opas poikkeuksellisen asiakaspalvelun tarjoamisesta, käsitellen aiheita kuten viestintätaidot, ongelmanratkaisu ja empatia. Tarjoa käytännön vinkkejä ja neuvoja asiakaspalveluedustajille, jotta he voivat tehokkaasti käsitellä asiakaskyselyjä ja tarjota ratkaisuja, jotka vastaavat asiakkaiden tarpeita.");

            // Lisää alakategoriat Sisällöntuotanto
            AddSubCategory("Sisällöntuotanto", "Kuinka luoda vakuuttavaa sisältöä sosiaaliseen mediaan?", "Luo opas vakuuttavan sisällön luomisesta sosiaaliseen mediaan, käsitellen aiheita kuten sisältöstrategia, visuaalinen suunnittelu ja sitouttamistaktiikat. Tarjoa käytännön vinkkejä ja neuvoja sisällöntuottajille, jotta he voivat tehokkaasti sitouttaa yleisönsä ja saavuttaa markkinointitavoitteensa.");

            // Lisää alakategoriat Robotiikka ja automaatio
            AddSubCategory("Robotiikka ja automaatio", "Mitkä ovat robotiikan ja automaation hyödyt valmistuksessa?", "Luo yleiskatsaus robotiikan ja automaation hyödyistä valmistuksessa, käsitellen aiheita kuten tehokkuuden lisääminen, turvallisuuden parantaminen ja kustannussäästöt. Tarjoa käytännön esimerkkejä ja neuvoja valmistajille, jotta he voivat tehokkaasti toteuttaa robotiikkaa ja automaatiota toiminnassaan.");

            // Lisää alakategoriat Markkinointi
            AddSubCategory("Markkinointi", "Kuinka kehität menestyksekkään markkinointistrategian?", "Luo opas menestyksekkään markkinointistrategian kehittämisestä, käsitellen aiheita kuten kohdeyleisön analyysi, asemoituminen ja viestintä. Tarjoa käytännön vinkkejä ja neuvoja markkinoijille, jotta he voivat luoda strategian, joka tehokkaasti edistää heidän tuotteitaan tai palveluitaan ja saavuttaa liiketoiminnan tavoitteet.");

            // Lisää alakategoriat Myynti
            AddSubCategory("Myynti", "Mitkä ovat menestyvien myyjien avainosaamiset?", "Luo opas menestyvien myyjien avainosaamisista, käsitellen aiheita kuten potentiaalisten asiakkaiden löytäminen, suhteen rakentaminen ja kaupan päättämistekniikat. Tarjoa käytännön vinkkejä ja neuvoja myyjille, jotta he voivat tehokkaasti viestiä tuotteidensa tai palveluidensa arvosta ja saada enemmän kauppoja aikaan.");

            // Lisää alakategoriat Toiminta
            AddSubCategory("Toiminnanohjaus", "Kuinka parannat toiminnan tehokkuutta?", "Luo opas toiminnan tehokkuuden parantamisesta, käsitellen aiheita kuten prosessikartoitus, työnkulun optimointi ja teknologian käyttöönotto. Tarjoa käytännön esimerkkejä ja neuvoja toiminnanjohtajille, jotta he voivat tunnistaa parannusmahdollisuuksia ja toteuttaa muutoksia, jotka lisäävät tehokkuutta ja vähentävät kustannuksia.");

            // Lisää alakategoriat Toimitusketjun hallinta
            AddSubCategory("Toimitusketjun hallinta", "Kuinka optimoit toimitusketjua?", "Luo opas toimitusketjun optimoinnista, käsitellen aiheita kuten varastonhallinta, logistiikka ja toimittajasuhteet. Tarjoa käytännön vinkkejä ja neuvoja toimitusketjun hallinnan ammattilaisille, jotta he voivat parantaa toimitusketjun toiminnan tehokkuutta ja luotettavuutta.");

            // Lisää alakategoriat Tietotekniikka
            AddSubCategory("Tietotekniikka", "Mitkä ovat parhaat käytännöt tietoturvan varmistamiseksi?", "Luo opas parhaista käytännöistä tietoturvan varmistamiseksi, käsitellen aiheita kuten verkon turvallisuus, tietojen suojaus ja tapahtumien hallinta. Tarjoa käytännön vinkkejä ja neuvoja IT-ammattilaisille, jotta he voivat suojata organisaationsa järjestelmiä ja tietoja kyberuhkilta.");

            // Lisää alakategoriat Projektinhallinta
            AddSubCategory("Projektinhallinta", "Kuinka hallitset onnistuneesti projektia?", "Luo opas onnistuneen projektin hallinnasta, käsitellen aiheita kuten projektin suunnittelu, tiimin hallinta ja riskienhallinta. Tarjoa käytännön vinkkejä ja neuvoja projektijohtajille, jotta he voivat suunnitella, toteuttaa ja toimittaa projekteja, jotka täyttävät heidän tavoitteensa.");

            // Lisää alakategoriat Laadunvarmistus
            AddSubCategory("Laadunvarmistus", "Mitkä ovat laadunvarmistuksen keskeiset periaatteet?", "Luo opas laadunvarmistuksen keskeisistä periaatteista, käsitellen aiheita kuten prosessien parantaminen, laadunvalvonta ja asiakastyytyväisyys. Tarjoa käytännön esimerkkejä ja neuvoja laadunvarmistuksen ammattilaisille, jotta he voivat varmistaa, että heidän tuotteensa tai palvelunsa täyttävät korkeimmat laatuvaatimukset.");

            // Lisää alakategoriat Tutkimus ja kehitys
            AddSubCategory("Tutkimus ja kehitys", "Kuinka teet tehokasta tutkimusta?", "Luo opas tehokkaan tutkimuksen tekemisestä, käsitellen aiheita kuten tutkimussuunnittelu, tiedonkeruu ja analyysi. Tarjoa käytännön vinkkejä ja neuvoja tutkijoille, jotta he voivat suunnitella ja toteuttaa tutkimusprojekteja, jotka tuottavat merkityksellisiä oivalluksia.");

            // Lisää alakategoriat Liiketoimintastrategia
            AddSubCategory("Liiketoimintastrategia", "Kuinka kehität menestyksekkään liiketoimintastrategian?", "Luo opas menestyksekkään liiketoimintastrategian kehittämisestä, käsitellen aiheita kuten markkina-analyysi, kilpailuasema ja resurssien kohdentaminen. Tarjoa käytännön vinkkejä ja neuvoja liiketoiminnan johtajille, jotta he voivat luoda strategian, joka asemoidaan organisaation pitkän aikavälin menestykselle.");

            // Lisää alakategoriat Johtajuus ja hallinto
            AddSubCategory("Johtajuus ja hallinto", "Mitkä ovat tehokkaiden johtajien keskeiset taidot?", "Luo opas tehokkaiden johtajien keskeisistä taidoista, käsitellen aiheita kuten viestintä, delegointi ja päätöksenteko. Tarjoa käytännön vinkkejä ja neuvoja johtajille, jotta he voivat rakentaa vahvoja tiimejä ja saavuttaa organisaationsa tavoitteet.");

            // Lisää alakategoriat Ympäristökestävyys
            AddSubCategory("Ympäristökestävyys", "Mitkä ovat parhaat käytännöt kestävän liiketoiminnan harjoittamiseksi?", "Luo opas parhaista käytännöistä kestävän liiketoiminnan harjoittamiseksi, käsitellen aiheita kuten energiatehokkuus, jätteen vähentäminen ja toimitusketjun kestävyys. Tarjoa käytännön vinkkejä ja neuvoja liiketoiminnan johtajille, jotta he voivat minimoida organisaationsa ympäristövaikutukset ja edistää kestävämpää tulevaisuutta.");

            // Lisää alakategoriat Sosiaalinen vastuu ja etiikka
            AddSubCategory("Sosiaalinen vastuu ja etiikka", "Kuinka edistät sosiaalista vastuuta ja eettistä käyttäytymistä työpaikalla?", "Luo opas sosiaalisen vastuun ja eettisen käyttäytymisen edistämisestä työpaikalla, käsitellen aiheita kuten monimuotoisuus ja inklusiivisuus, eettinen päätöksenteko ja yritysvastuu. Tarjoa käytännön vinkkejä ja neuvoja liiketoiminnan johtajille, jotta he voivat luoda kulttuurin, joka edistää sosiaalista vastuuta ja eettistä käyttäytymistä organisaatiossa.");

            // Lisää alakategoriat terveydenhuoltoon
            AddSubCategory("Terveydenhuolto", "Mitkä ovat viimeisimmät trendit terveysteknologiassa?", "Luo yleiskatsaus viimeisimmistä terveysteknologian trendeistä, käsitellen aiheita kuten etälääketiede, wearable-laitteet ja tekoäly. Tarjoa käytännön esimerkkejä ja neuvoja terveydenhuollon ammattilaisille, jotta he voivat hyödyntää teknologiaa tehokkaasti potilaiden tulosten parantamiseksi ja paremman hoidon tarjoamiseksi.");

            // Lisää alakategoriat suunnitteluun ja mediaan
            AddSubCategory("Suunnittelu & Media", "Miten luodaan tehokasta visuaalista sisältöä?", "Luo opas tehokkaan visuaalisen sisällön luomisesta, käsitellen aiheita kuten suunnitteluperiaatteet, visuaalinen tarinankerronta ja brändin yhdenmukaisuus. Tarjoa käytännön vinkkejä ja neuvoja suunnittelijoille ja markkinoijille, jotta he voivat luoda visuaalisesti houkuttelevaa sisältöä, joka välittää tehokkaasti heidän viestinsä.");

            // Lisää alakategoriat koulutukseen
            AddSubCategory("Koulutus", "Miten luodaan osallistavia verkkokoulutuskokemuksia?", "Luo opas osallistavien verkkokoulutuskokemusten luomisesta, käsitellen aiheita kuten opetuksen suunnittelu, multimedia-sisältö ja interaktiiviset aktiviteetit. Tarjoa käytännön vinkkejä ja neuvoja opettajille ja opetuksen suunnittelijoille, jotta he voivat luoda verkkokursseja, jotka sitouttavat oppijat ja helpottavat oppimista.");

            // Lisää alakategoriat kieleen ja kääntämiseen
            AddSubCategory("Kieli & Kääntäminen", "Mitkä ovat parhaat käytännöt sisällön kääntämisessä?", "Luo opas parhaista käytännöistä sisällön kääntämisessä, käsitellen aiheita kuten käännöslaatu, kulttuurinen sopeutuminen ja lokalisaatio. Tarjoa käytännön vinkkejä ja neuvoja kääntäjille ja lokalisaatiospesialisteille, jotta he voivat kääntää sisältöä tehokkaasti ja varmistaa sen tarkkuuden ja tehokkuuden eri kielissä ja kulttuureissa.");

            // Lisää alakategoriat asiakaspalveluun
            AddSubCategory("Asiakaspalvelu", "Miten tarjota erinomaista asiakaspalvelua?", "Luo opas erinomaisen asiakaspalvelun tarjoamisesta, käsitellen aiheita kuten asiakaskommunikaatio, ongelmanratkaisu ja asiakaspalaute. Tarjoa käytännön vinkkejä ja neuvoja asiakaspalveluedustajille ja -johtajille, jotta he voivat täyttää asiakkaiden tarpeet ja rakentaa vahvoja asiakassuhteita.");

            // Lisää alakategoriat sisällöntuotantoon
            AddSubCategory("Sisällöntuotanto", "Miten luodaan vakuuttavaa sisältöä?", "Luo opas vakuuttavan sisällön luomisesta, käsitellen aiheita kuten sisältöstrategia, kohdeyleisön kohdistaminen ja tarinankerronta. Tarjoa käytännön vinkkejä ja neuvoja sisällöntuottajille ja markkinoijille, jotta he voivat luoda sisältöä, joka sitouttaa kohdeyleisön ja saavuttaa liiketoiminnan tavoitteet.");

            // Lisää alakategoriat lakiasioihin
            AddSubCategory("Laki", "Mitkä ovat viimeisimmät kehitykset immateriaalioikeuksien lainsäädännössä?", "Luo yleiskatsaus viimeisimmistä kehityksistä immateriaalioikeuksien lainsäädännössä, käsitellen aiheita kuten patentit, tavaramerkit ja tekijänoikeudet. Tarjoa käytännön esimerkkejä ja neuvoja asianajajille ja yrityksille, jotta he voivat suojata immateriaalioikeutensa tehokkaasti ja navigoida muuttuvassa oikeudellisessa maisemassa.");

            // Create categories
            categories = new List<string> {
    "Software dev",
    "Finance",
    "Legal",
    "Human Resources",
    "Healthcare",
    "Design & Media",
    "Education",
    "Language & Translation",
    "Data Analysis",
    "Customer Support",
    "Content Creation",
    "Robotics & Automation",
    "Marketing",
    "Sales",
    "Operations",
    "Supply Chain Management",
    "Information Technology",
    "Project Management",
    "Quality Assurance",
    "Research and Development",
    "Business Strategy",
    "Leadership and Management",
    "Environmental Sustainability",
    "Social Responsibility and Ethics",
    "Cybersecurity",
    "Artificial Intelligence",
    "Mobile App Development",
    "Web Development",
    "Cloud Computing",
    "E-commerce",
    "Accounting",
    "Insurance",
    "Real Estate",
    "Hospitality",
    "Travel and Tourism",
    "Nonprofit and Philanthropy",
    "Event Planning",
    "Public Relations",
    "Advertising",
    "Journalism",
    "Photography",
    "Videography",
    "Music Production",
    "Performing Arts",
    "Fine Arts",
    "Architecture",
    "Interior Design",
    "Fashion Design",
    "Culinary Arts",
    "Sports and Fitness",
    "Personal Training",
    "Beauty and Wellness",
    "Automotive",
    "Construction and Engineering"
};


            // Add top-level categories
            foreach (var category in categories)
            {
                treeViewBuilder.AddTopLevelCategory(category, Properties.Resources._2890580_ai_artificial_intelligence_brain_electronics_robotics_icon_24);
            }


            // Add subcategories Software dev
            AddSubCategory("Software dev", "How do you prioritize debugging efforts in a complex software project?", "Create a guide on prioritizing debugging efforts in a complex software project, focusing on key aspects like parameter1, parametter2, and parameter3. Explain the importance of each aspect and provide actionable steps for software developers to improve their debugging process effectively.");
            AddSubCategory("Software dev", "What are the best practices for code reviews?", "Create a comprehensive guide on the best practices for conducting code reviews, including tips on how to provide constructive feedback, how to identify common coding errors, and how to ensure code quality and consistency.");
            AddSubCategory("Software dev", "How do you optimize database performance?", "Write an article on the key strategies for optimizing database performance, including indexing, query optimization, and database design best practices.");
            AddSubCategory("Software dev", "What are the most common software development methodologies?", "Create a guide that explains the most common software development methodologies, including Agile, Waterfall, and Scrum. Discuss the pros and cons of each methodology and provide examples of when each one is most appropriate.");
            AddSubCategory("Software dev", "How do you ensure software security?", "Write an article on the key strategies for ensuring software security, including secure coding practices, vulnerability testing, and threat modeling.");
            AddSubCategory("Software dev", "What are the best tools for software development?", "Create a list of the best tools for software development, including IDEs, version control systems, and testing frameworks. Provide a brief overview of each tool and explain why it is useful for software developers.");
            AddSubCategory("Software dev", "How do you manage software dependencies?", "Write an article on the best practices for managing software dependencies, including how to identify and resolve conflicts, how to handle versioning, and how to ensure compatibility.");
            AddSubCategory("Software dev", "What are the key principles of software architecture?", "Create a guide that explains the key principles of software architecture, including modularity, scalability, and maintainability. Provide examples of how these principles can be applied in real-world software development projects.");
            AddSubCategory("Software dev", "How do you implement continuous integration and deployment?", "Write an article on the key strategies for implementing continuous integration and deployment, including how to automate testing and deployment processes, how to use build tools, and how to ensure code quality.");
            AddSubCategory("Software dev", "What are the best practices for software documentation?", "Create a guide on the best practices for software documentation, including how to write clear and concise documentation, how to organize documentation effectively, and how to ensure documentation is up-to-date.");
            AddSubCategory("Software dev", "How do you manage software project timelines?", "Write an article on the best practices for managing software project timelines, including how to estimate project timelines accurately, how to identify and mitigate risks, and how to communicate project progress effectively to stakeholders.");

            // Add subcategories for Finance
            AddSubCategory("Finance", "What are the key financial ratios used in business analysis?", "Create a guide that explains the key financial ratios used in business analysis, including profitability ratios, liquidity ratios, and solvency ratios. Provide examples of how these ratios can be used to evaluate a company's financial health.");
            AddSubCategory("Finance", "How do you create a financial budget for a business?", "Write an article on the best practices for creating a financial budget for a business, including how to forecast revenue and expenses, how to identify and prioritize budget items, and how to monitor and adjust the budget over time.");
            AddSubCategory("Finance", "What are the different types of financial statements?", "Create a guide that explains the different types of financial statements, including the balance sheet, income statement, and cash flow statement. Discuss the purpose of each statement and provide examples of how they can be used to evaluate a company's financial performance.");
            AddSubCategory("Finance", "How do you evaluate investment opportunities?", "Write an article on the key strategies for evaluating investment opportunities, including how to calculate return on investment, how to assess risk, and how to identify and analyze market trends.");
            AddSubCategory("Finance", "What are the best practices for financial risk management?", "Create a guide on the best practices for financial risk management, including how to identify and assess financial risks, how to develop risk mitigation strategies, and how to monitor and adjust risk management plans over time.");
            AddSubCategory("Finance", "How do you create a financial forecast for a business?", "Write an article on the best practices for creating a financial forecast for a business, including how to use historical data and market trends to make projections, how to identify and prioritize forecast items, and how to monitor and adjust the forecast over time.");
            AddSubCategory("Finance", "What are the key financial metrics used in business analysis?", "Create a guide that explains the key financial metrics used in business analysis, including revenue growth, profit margin, and return on investment. Provide examples of how these metrics can be used to evaluate a company's financial performance.");
            AddSubCategory("Finance", "How do you manage cash flow for a business?", "Write an article on the best practices for managing cash flow for a business, including how to forecast cash flow, how to identify and prioritize cash flow items, and how to monitor and adjust cash flow over time.");
            AddSubCategory("Finance", "What are the best practices for financial reporting?", "Create a guide on the best practices for financial reporting, including how to prepare financial statements, how to ensure accuracy and completeness, and how to communicate financial information effectively to stakeholders.");
            AddSubCategory("Finance", "How do you create a financial model for a business?", "Write an article on the best practices for creating a financial model for a business, including how to use historical data and market trends to make projections, how to identify and prioritize model items, and how to monitor and adjust the model over time.");

            // Add subcategories for Legal
            AddSubCategory("Legal", "What are the different types of legal contracts?", "Create a guide that explains the different types of legal contracts, including employment contracts, non-disclosure agreements, and lease agreements. Discuss the purpose of each contract and provide examples of when they might be used.");
            AddSubCategory("Legal", "What are the best practices for protecting intellectual property?", "Write an article on the best practices for protecting intellectual property, including patents, trademarks, and copyrights. Discuss the legal requirements for protecting intellectual property and provide examples of how to apply them in practice.");
            AddSubCategory("Legal", "How do you navigate legal compliance for a business?", "Create a guide on how to navigate legal compliance for a business, including understanding and complying with relevant laws and regulations, creating policies and procedures, and training employees on compliance requirements.");
            AddSubCategory("Legal", "What are the different types of business structures and their legal implications?", "Create a guide that explains the different types of business structures, including sole proprietorship, partnership, limited liability company, and corporation. Discuss the legal implications of each structure and provide guidance on how to choose the appropriate structure for a business.");
            AddSubCategory("Legal", "What are the key employment laws every business owner should know?", "Write an article on the key employment laws that every business owner should be aware of, including minimum wage, overtime, anti-discrimination, and workplace safety laws. Provide examples of how these laws can impact a business and how to comply with them.");
            AddSubCategory("Legal", "What are the key legal considerations for starting a new business?", "Create a checklist of key legal considerations for entrepreneurs who are starting a new business, covering topics such as business registration, intellectual property protection, contracts, and liability. Provide practical advice and guidance for new business owners to ensure they are complying with all relevant laws and regulations.");

            // Add subcategories for Human Resources
            AddSubCategory("Human Resources", "How do you conduct effective performance evaluations?", "Write an article on how to conduct effective performance evaluations, including setting performance goals, providing constructive feedback, and documenting performance reviews.");
            AddSubCategory("Human Resources", "What are the best practices for employee onboarding?", "Create a guide on the best practices for employee onboarding, including creating an onboarding program, setting clear expectations, and integrating new employees into the company culture.");
            AddSubCategory("Human Resources", "How do you create an effective employee development program?", "Write an article on how to create an effective employee development program, including identifying employee development needs, designing training programs, and measuring the effectiveness of employee development.");
            AddSubCategory("Human Resources", "How do you conduct effective employee performance evaluations?", "Write an article on the best practices for conducting employee performance evaluations, including how to set clear performance goals, how to provide constructive feedback, and how to create actionable performance improvement plans.");
            AddSubCategory("Human Resources", "What are the best practices for creating an employee training and development program?", "Create a guide on the best practices for creating an employee training and development program, including how to identify training needs, how to design effective training programs, and how to evaluate training effectiveness.");
            AddSubCategory("Human Resources", "How do you create an effective employee training program?", "Create a guide on designing and implementing an effective employee training program, covering topics such as needs assessment, program design, delivery methods, and evaluation. Provide practical tips and advice for HR professionals to create a training program that meets the needs of their organization and helps employees develop the skills they need to succeed.");

            // Add subcategories for Healthcare
            AddSubCategory("Healthcare", "What are the best practices for patient care?", "Create a guide on the best practices for patient care, including effective communication with patients, managing patient expectations, and providing patient-centered care.");
            AddSubCategory("Healthcare", "How do you ensure patient safety in healthcare?", "Write an article on how to ensure patient safety in healthcare, including identifying and mitigating risks, implementing safety protocols, and promoting a culture of safety in the workplace.");
            AddSubCategory("Healthcare", "What are the best practices for healthcare administration?", "Create a guide on the best practices for healthcare administration, including managing healthcare finances, optimizing workflow, and staying up-to-date with healthcare regulations.");
            AddSubCategory("Healthcare", "What are the key trends and challenges in the healthcare industry?", "Write an article on the key trends and challenges facing the healthcare industry, including emerging technologies, changing regulations, and evolving patient needs. Discuss the implications of these trends and challenges for healthcare organizations.");
            AddSubCategory("Healthcare", "How do you implement effective healthcare quality improvement initiatives?", "Create a guide on the best practices for implementing effective quality improvement initiatives in healthcare organizations, including how to identify improvement opportunities, how to design improvement projects, and how to monitor and evaluate project outcomes.");
            AddSubCategory("Healthcare", "What are the most important trends in healthcare technology?", "Create an overview of the most important trends in healthcare technology, covering topics such as electronic health records, telemedicine, artificial intelligence, and wearable devices. Provide practical examples of how these technologies are being used to improve patient outcomes and streamline healthcare delivery.");

            // Add subcategories for Design & Media
            AddSubCategory("Design & Media", "How do you create effective visual designs?", "Write an article on how to create effective visual designs, including choosing the right colors, typography, and layout, and optimizing visual designs for different mediums.");
            AddSubCategory("Design & Media", "What are the best practices for user experience design?", "Create a guide on the best practices for user experience design, including conducting user research, designing user interfaces, and testing and iterating designs based on user feedback.");
            AddSubCategory("Design & Media", "How do you create effective marketing materials?", "Write an article on how to create effective marketing materials, including designing marketing campaigns, creating compelling copy, and choosing the right marketing channels to reach target audiences.");
            AddSubCategory("Design & Media", "What are the best practices for creating effective graphic design?", "Write an article on the best practices for creating effective graphic design, including how to use color, typography, and layout to communicate a message and evoke emotion. Provide examples of effective graphic design and discuss the principles behind them.");
            AddSubCategory("Design & Media", "How do you create a successful social media marketing campaign?", "Create a guide on the best practices for creating a successful social media marketing campaign, including how to set goals, how to identify target audiences, and how to develop and distribute engaging content.");
            AddSubCategory("Design & Media", "What are the key principles of graphic design?", "Create a guide to the key principles of graphic design, covering topics such as typography, color theory, composition, and visual hierarchy. Provide practical examples and advice for designers to create visually appealing and effective designs for a range of mediums.");

            // Add subcategories for Education
            AddSubCategory("Education", "How do you create effective lesson plans?", "Write an article on how to create effective lesson plans, including setting learning objectives, choosing appropriate teaching methods, and evaluating student learning outcomes.");
            AddSubCategory("Education", "What are the best practices for student assessment?", "Create a guide on the best practices for student assessment, including designing assessment tools, grading and providing feedback, and using assessment data to inform instruction.");
            AddSubCategory("Education", "What are the key trends and challenges in education?", "Write an article on the key trends and challenges facing the education industry, including emerging technologies, changing student needs, and evolving teaching methods. Discuss the implications of these trends and challenges for educational institutions.");
            AddSubCategory("Education", "How do you create an effective online learning program?", "Create a guide on the best practices for creating an effective online learning program, including how to design engaging and interactive courses, how to evaluate learning outcomes, and how to create a supportive online learning community.");
            AddSubCategory("Education", "How do you design an effective online course?", "Create a guide on designing and delivering effective online courses, covering topics such as instructional design, multimedia development, and assessment. Provide practical tips and advice for educators to create engaging and effective online courses that meet the needs of their learners.");

            //Write "Language & Translation",
            AddSubCategory("Language & Translation", "What are the best practices for professional translation services?", "Write an article on the best practices for providing professional translation services, including how to manage translation projects, how to ensure quality and accuracy, and how to maintain confidentiality and security.");
            AddSubCategory("Language & Translation", "How do you conduct effective cross-cultural communication?", "Create a guide on the best practices for conducting effective cross-cultural communication, including how to understand cultural differences, how to adapt communication styles, and how to build rapport and trust with people from different cultures.");
            AddSubCategory("Language & Translation", "What are the best practices for translating technical documents?", "Create a guide on best practices for translating technical documents, covering topics such as terminology management, translation memory tools, and quality assurance. Provide practical tips and advice for translators to produce accurate and effective translations of technical content.");

            // Add subcategories Data Analysis
            AddSubCategory("Data Analysis", "What are the key steps in the data analysis process?", "Create a guide on the key steps in the data analysis process, covering topics such as data collection, cleaning, analysis, and visualization. Provide practical examples and advice for data analysts to effectively analyze and communicate insights from data.");

            // Add subcategories Customer Support
            AddSubCategory("Customer Support", "How do you provide exceptional customer service?", "Create a guide on providing exceptional customer service, covering topics such as communication skills, problem-solving, and empathy. Provide practical tips and advice for customer service representatives to effectively handle customer inquiries and provide solutions that meet their needs.");

            // Add subcategories Content Creation
            AddSubCategory("Content Creation", "How do you create compelling content for social media?", "Create a guide on creating compelling content for social media, covering topics such as content strategy, visual design, and engagement tactics. Provide practical tips and advice for content creators to effectively engage their audience and achieve their marketing goals.");

            // Add subcategories Robotics & Automation
            AddSubCategory("Robotics & Automation", "What are the benefits of using robotics and automation in manufacturing?", "Create an overview of the benefits of using robotics and automation in manufacturing, covering topics such as increased efficiency, improved safety, and cost savings. Provide practical examples and advice for manufacturers to effectively implement robotics and automation in their operations.");

            // Add subcategories Marketing
            AddSubCategory("Marketing", "How do you develop a successful marketing strategy?", "Create a guide on developing a successful marketing strategy, covering topics such as target audience analysis, positioning, and messaging. Provide practical tips and advice for marketers to create a strategy that effectively promotes their products or services and achieves their business goals.");

            // Add subcategories Sales
            AddSubCategory("Sales", "What are the key skills for successful salespeople?", "Create a guide to the key skills for successful salespeople, covering topics such as prospecting, rapport building, and closing techniques. Provide practical tips and advice for salespeople to effectively communicate the value of their products or services and close more deals.");

            // Add subcategories Operations
            AddSubCategory("Operations", "How do you improve operational efficiency?", "Create a guide on improving operational efficiency, covering topics such as process mapping, workflow optimization, and technology implementation. Provide practical examples and advice for operations managers to identify opportunities for improvement and implement changes that increase efficiency and reduce costs.");

            // Add subcategories Supply Chain Management
            AddSubCategory("Supply Chain Management", "How do you optimize the supply chain?", "Create a guide on optimizing the supply chain, covering topics such as inventory management, logistics, and supplier relationships. Provide practical tips and advice for supply chain managers to improve the efficiency and reliability of their supply chain operations.");

            // Add subcategories Information Technology
            AddSubCategory("Information Technology", "What are the best practices for cybersecurity?", "Create a guide on best practices for cybersecurity, covering topics such as network security, data protection, and incident response. Provide practical tips and advice for IT professionals to protect their organization's systems and data from cyber threats.");

            // Add subcategories Project Management
            AddSubCategory("Project Management", "How do you manage a successful project?", "Create a guide on managing a successful project, covering topics such as project planning, team management, and risk management. Provide practical tips and advice for project managers to effectively plan, execute, and deliver projects that meet their objectives.");

            // Add subcategories Quality Assurance
            AddSubCategory("Quality Assurance", "What are the key principles of quality assurance?", "Create a guide to the key principles of quality assurance, covering topics such as process improvement, quality control, and customer satisfaction. Provide practical examples and advice for quality assurance professionals to ensure the products or services they deliver meet the highest standards of quality.");

            // Add subcategories Research and Development
            AddSubCategory("Research and Development", "How do you conduct effective research?", "Create a guide on conducting effective research, covering topics such as research design, data collection, and analysis. Provide practical tips and advice for researchers to effectively design and conduct research studies that generate meaningful insights.");

            // Add subcategories Business Strategy
            AddSubCategory("Business Strategy", "How do you develop a successful business strategy?", "Create a guide on developing a successful business strategy, covering topics such as market analysis, competitive positioning, and resource allocation. Provide practical tips and advice for business leaders to create a strategy that effectively positions their organization for long-term success.");

            // Add subcategories Leadership and Management
            AddSubCategory("Leadership and Management", "What are the key skills for effective leaders?", "Create a guide to the key skills for effective leaders, covering topics such as communication, delegation, and decision-making. Provide practical tips and advice for leaders to build strong teams and achieve their organization's goals.");

            // Add subcategories Environmental Sustainability
            AddSubCategory("Environmental Sustainability", "What are the best practices for sustainable business operations?", "Create a guide on best practices for sustainable business operations, covering topics such as energy efficiency, waste reduction, and supply chain sustainability. Provide practical tips and advice for business leaders to minimize their organization's environmental footprint and contribute to a more sustainable future.");

            // Add subcategories Social Responsibility and Ethics
            AddSubCategory("Social Responsibility and Ethics", "How do you promote social responsibility and ethical behavior in the workplace?", "Create a guide on promoting social responsibility and ethical behavior in the workplace, covering topics such as diversity and inclusion, ethical decision-making, and corporate social responsibility. Provide practical tips and advice for business leaders to create a culture of social responsibility and ethical behavior within their organization.");

            // Add subcategories Healthcare
            AddSubCategory("Healthcare", "What are the latest trends in healthcare technology?", "Create an overview of the latest trends in healthcare technology, covering topics such as telemedicine, wearable devices, and artificial intelligence. Provide practical examples and advice for healthcare professionals to effectively leverage technology to improve patient outcomes and deliver better care.");

            // Add subcategories Design & Media
            AddSubCategory("Design & Media", "How do you create effective visual content?", "Create a guide on creating effective visual content, covering topics such as design principles, visual storytelling, and brand consistency. Provide practical tips and advice for designers and marketers to create visually appealing content that effectively communicates their message.");

            // Add subcategories Education
            AddSubCategory("Education", "How do you create engaging online learning experiences?", "Create a guide on creating engaging online learning experiences, covering topics such as instructional design, multimedia content, and interactive activities. Provide practical tips and advice for educators and instructional designers to create online courses that effectively engage learners and facilitate learning.");

            // Add subcategories Language & Translation
            AddSubCategory("Language & Translation", "What are the best practices for translating content?", "Create a guide on best practices for translating content, covering topics such as translation quality, cultural adaptation, and localization. Provide practical tips and advice for translators and localization specialists to effectively translate content and ensure its accuracy and effectiveness in different languages and cultures.");

            // Add subcategories Customer Support
            AddSubCategory("Customer Support", "How do you provide excellent customer service?", "Create a guide on providing excellent customer service, covering topics such as customer communication, issue resolution, and customer feedback. Provide practical tips and advice for customer service representatives and managers to effectively meet customers' needs and build strong customer relationships.");

            // Add subcategories Content Creation
            AddSubCategory("Content Creation", "How do you create compelling content?", "Create a guide on creating compelling content, covering topics such as content strategy, audience targeting, and storytelling. Provide practical tips and advice for content creators and marketers to create content that effectively engages their target audience and achieves their business goals.");

            // Add subcategories Legal
            AddSubCategory("Legal", "What are the latest developments in intellectual property law?", "Create an overview of the latest developments in intellectual property law, covering topics such as patents, trademarks, and copyright. Provide practical examples and advice for attorneys and businesses to effectively protect their intellectual property rights and navigate the evolving legal landscape.");

            // Add event handler for TreeView's NodeMouseClick event
            promptTree.NodeMouseClick += PromptTree_NodeMouseClick; ;


        }

        private void AddSubCategory(string category, string description, string prompt)
        {
            treeViewBuilder.AddSubCategory(category, description, Properties.Resources._4575066_artificial_brain_computer_consciousness_electronic_icon_24, prompt);

        }

        private void PromptTree_NodeMouseClick(object? sender, TreeNodeMouseClickEventArgs e)
        {

            // Check if the clicked node is a sub item
            if (e.Node.Parent != null)
            {
                // Get the text associated with the clicked node's tag
                string tagText = e.Node.Tag?.ToString();

                // Show a message box with the tag text
                if (!string.IsNullOrEmpty(tagText))
                {
                    SmartAgent smartAgent = new SmartAgent(null, sAM, tagText);

                    smartAgent.Show(dockPanelSAM);
                }
            }


        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateSuggestionsAsync();
        }
        private string GetSelectedTreeViewRootNodeText(System.Windows.Forms.TreeView treeView)
        {
            if (treeView.SelectedNode != null)
            {
                TreeNode rootNode = treeView.SelectedNode;
                while (rootNode.Parent != null)
                {
                    rootNode = rootNode.Parent;
                }
                return rootNode.Text;
            }
            return null;
        }

        private async Task GenerateSuggestionsAsync()
        {
            Invoke((Action)(() => Processing.Visible = true));
            var selectedArea = GetSelectedTreeViewRootNodeText(this.promptTree);
            if (selectedArea != null)
            {
                List<string> role = new List<string>();
                role.Add(SamUserSettings.Default.DefaultAgentPersonality);
                var conversation = new Conversation(SamUserSettings.Default.GPT_API_KEY, role, role, new List<string>(), Guid.NewGuid().ToString(), (float)0.8);

                var response = await conversation.StartConversation("Luo satunnainen rooli alalle " + selectedArea + ", älä tee tekosyitä. Vastaa vain tässä muodossa: Haluan sinun toimivan [tiettynä roolina]. Anna minulle tietoja tai apua liittyen [erityiseen tehtävään tai aiheeseen].", true, (float)1);
                AddSubCategory(selectedArea, response.First(), response.First());
                conversation.ClearChatHistory();

                response = await conversation.StartConversation("Luo kirjoituskehote " + selectedArea + ", älä keksi tekosyitä. Vastaa vain tämän mallin mukaan: Haluan sinun toimivan[tietty kenttä tai rooli].Ole hyvä ja toimita minulle asiantunteva kirjoitus[tietty tehtävä tai aihe].", true, (float)1);
                AddSubCategory(selectedArea, response.First(), response.First());
                conversation.ClearChatHistory();

                response = await conversation.StartConversation("Get a random role for " + selectedArea + ", make no excuses. Give only this template: I want you to act as [specific field or role]. Please provide me with information or assistance related to[specific task or topic].", true, (float)1);
                AddSubCategory(selectedArea, response.First(), response.First());
                conversation.ClearChatHistory();

                response = await conversation.StartConversation("Generate professional writing promt for " + selectedArea + ", make no excuses. Give only this template: I want you to act as [specific field or role]. Please provide me a professional writing [specific task or topic].", true, (float)1);
                AddSubCategory(selectedArea, response.First(), response.First());
                conversation.ClearChatHistory();

            }
            Invoke((Action)(() => Processing.Visible = false));


        }
    }
}

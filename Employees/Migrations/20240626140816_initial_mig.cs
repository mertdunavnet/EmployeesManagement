using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Employees.Migrations
{
    /// <inheritdoc />
    public partial class initialmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Department = table.Column<string>(type: "TEXT", nullable: true),
                    Avatar = table.Column<string>(type: "TEXT", nullable: true),
                    LastModified = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Avatar", "Department", "Email", "FirstName", "LastModified", "LastName" },
                values: new object[,]
                {
                    { 1, "https://robohash.org/autautea.png?size=100x100&set=set1", "Research and Development", "nmorgue0@disqus.com", "Nonie", null, "Morgue" },
                    { 2, "https://robohash.org/saepeadipiscifugit.png?size=100x100&set=set1", "Research and Development", "klowe1@nymag.com", "Krishna", null, "Lowe" },
                    { 3, "https://robohash.org/atquerepudiandaecorporis.png?size=100x100&set=set1", "Research and Development", "owilliamson2@washingtonpost.com", "Orville", null, "Williamson" },
                    { 4, "https://robohash.org/liberotemporibusalias.png?size=100x100&set=set1", "Product Management", "ditzkovici3@phpbb.com", "Dwayne", null, "Itzkovici" },
                    { 5, "https://robohash.org/enimsapienteillum.png?size=100x100&set=set1", "Research and Development", "sjerisch4@craigslist.org", "Shelbi", null, "Jerisch" },
                    { 6, "https://robohash.org/omnisillumnostrum.png?size=100x100&set=set1", "Services", "jwitcherley5@1und1.de", "Jerrilee", null, "Witcherley" },
                    { 7, "https://robohash.org/adipiscisequidolor.png?size=100x100&set=set1", "Marketing", "ckobpac6@goo.ne.jp", "Caritta", null, "Kobpac" },
                    { 8, "https://robohash.org/aliquamquassunt.png?size=100x100&set=set1", "Human Resources", "qmccague7@facebook.com", "Quincey", null, "McCague" },
                    { 9, "https://robohash.org/eaquiserror.png?size=100x100&set=set1", "Accounting", "acundey8@yahoo.com", "Aharon", null, "Cundey" },
                    { 10, "https://robohash.org/dolorconsecteturdeleniti.png?size=100x100&set=set1", "Services", "nanthill9@posterous.com", "Neila", null, "Anthill" },
                    { 11, "https://robohash.org/veroculpadolore.png?size=100x100&set=set1", "Business Development", "cbroadera@theglobeandmail.com", "Cinnamon", null, "Broader" },
                    { 12, "https://robohash.org/autveritatisquibusdam.png?size=100x100&set=set1", "Business Development", "gtampinb@example.com", "Godfrey", null, "Tampin" },
                    { 13, "https://robohash.org/utvoluptasdolorum.png?size=100x100&set=set1", "Support", "oandrellic@t-online.de", "Olimpia", null, "Andrelli" },
                    { 14, "https://robohash.org/odioinqui.png?size=100x100&set=set1", "Human Resources", "gebblesd@fema.gov", "Grissel", null, "Ebbles" },
                    { 15, "https://robohash.org/saepedelenitivoluptas.png?size=100x100&set=set1", "Sales", "bsutherleye@bing.com", "Beckie", null, "Sutherley" },
                    { 16, "https://robohash.org/aspernaturautdicta.png?size=100x100&set=set1", "Sales", "dschohierf@dion.ne.jp", "Drusie", null, "Schohier" },
                    { 17, "https://robohash.org/dolornobisratione.png?size=100x100&set=set1", "Sales", "aheisterg@soup.io", "Aida", null, "Heister" },
                    { 18, "https://robohash.org/estnihilsuscipit.png?size=100x100&set=set1", "Services", "vleakeh@umn.edu", "Valentia", null, "Leake" },
                    { 19, "https://robohash.org/abperspiciatismagnam.png?size=100x100&set=set1", "Training", "ogellatelyi@spotify.com", "Octavius", null, "Gellately" },
                    { 20, "https://robohash.org/blanditiisvoluptasrerum.png?size=100x100&set=set1", "Product Management", "emandyj@webs.com", "Erwin", null, "Mandy" },
                    { 21, "https://robohash.org/auteavel.png?size=100x100&set=set1", "Engineering", "adevenportk@google.fr", "Armand", null, "Devenport" },
                    { 22, "https://robohash.org/consequuntureveniethic.png?size=100x100&set=set1", "Research and Development", "btorell@mit.edu", "Bartel", null, "Torel" },
                    { 23, "https://robohash.org/fugitmagnamhic.png?size=100x100&set=set1", "Research and Development", "aludgatem@ning.com", "Auberta", null, "Ludgate" },
                    { 24, "https://robohash.org/voluptatumetet.png?size=100x100&set=set1", "Support", "csendalln@bizjournals.com", "Claudian", null, "Sendall" },
                    { 25, "https://robohash.org/cupiditateestsoluta.png?size=100x100&set=set1", "Engineering", "sdarrello@auda.org.au", "Saw", null, "Darrell" },
                    { 26, "https://robohash.org/quosconsequaturqui.png?size=100x100&set=set1", "Research and Development", "anarracottp@dedecms.com", "Arv", null, "Narracott" },
                    { 27, "https://robohash.org/temporibusperspiciatiscommodi.png?size=100x100&set=set1", "Sales", "scloustonq@ow.ly", "Silvia", null, "Clouston" },
                    { 28, "https://robohash.org/eoseosdoloremque.png?size=100x100&set=set1", "Support", "fartistr@fda.gov", "Fabio", null, "Artist" },
                    { 29, "https://robohash.org/nihiloptiout.png?size=100x100&set=set1", "Sales", "elents@wikimedia.org", "Eldredge", null, "Lent" },
                    { 30, "https://robohash.org/solutaarchitectovoluptate.png?size=100x100&set=set1", "Business Development", "agoodlettt@yellowbook.com", "Arlin", null, "Goodlett" },
                    { 31, "https://robohash.org/teneturquidemexercitationem.png?size=100x100&set=set1", "Legal", "fkeyseu@mac.com", "Fenelia", null, "Keyse" },
                    { 32, "https://robohash.org/eligenditotamdelectus.png?size=100x100&set=set1", "Training", "mshawlv@is.gd", "Merilyn", null, "Shawl" },
                    { 33, "https://robohash.org/dolorevoluptatibusaut.png?size=100x100&set=set1", "Accounting", "mwadelinw@bravesites.com", "Maryellen", null, "Wadelin" },
                    { 34, "https://robohash.org/delenitiomnisperferendis.png?size=100x100&set=set1", "Sales", "bvanyukovx@vinaora.com", "Blondie", null, "Vanyukov" },
                    { 35, "https://robohash.org/nostrumharumeveniet.png?size=100x100&set=set1", "Engineering", "lliccardoy@unicef.org", "Leon", null, "Liccardo" },
                    { 36, "https://robohash.org/corporisquibusdamnisi.png?size=100x100&set=set1", "Engineering", "tburneyz@mac.com", "Theodosia", null, "Burney" },
                    { 37, "https://robohash.org/laudantiumillorepellendus.png?size=100x100&set=set1", "Accounting", "tbenedyktowicz10@indiatimes.com", "Tiffany", null, "Benedyktowicz" },
                    { 38, "https://robohash.org/similiquerepellatitaque.png?size=100x100&set=set1", "Business Development", "swathey11@fc2.com", "Salomon", null, "Wathey" },
                    { 39, "https://robohash.org/utmaximeet.png?size=100x100&set=set1", "Sales", "fmeineking12@cbsnews.com", "Fidelio", null, "Meineking" },
                    { 40, "https://robohash.org/doloresomnisaut.png?size=100x100&set=set1", "Support", "fdemicoli13@earthlink.net", "Ford", null, "De Micoli" },
                    { 41, "https://robohash.org/nostrumdoloremqueillum.png?size=100x100&set=set1", "Accounting", "bstebbings14@bbc.co.uk", "Bridie", null, "Stebbings" },
                    { 42, "https://robohash.org/porroenimdolorem.png?size=100x100&set=set1", "Business Development", "tkarpets15@cmu.edu", "Theressa", null, "Karpets" },
                    { 43, "https://robohash.org/earumquiaest.png?size=100x100&set=set1", "Services", "tleivesley16@prlog.org", "Twyla", null, "Leivesley" },
                    { 44, "https://robohash.org/voluptatevoluptatemexcepturi.png?size=100x100&set=set1", "Product Management", "acroney17@purevolume.com", "Alane", null, "Croney" },
                    { 45, "https://robohash.org/possimusvoluptatesquas.png?size=100x100&set=set1", "Sales", "aurrey18@seesaa.net", "Althea", null, "Urrey" },
                    { 46, "https://robohash.org/magnamaliasveritatis.png?size=100x100&set=set1", "Business Development", "dphifer19@yale.edu", "Desiri", null, "Phifer" },
                    { 47, "https://robohash.org/idquaesint.png?size=100x100&set=set1", "Services", "cmeecher1a@walmart.com", "Cicily", null, "Meecher" },
                    { 48, "https://robohash.org/magnipariaturdolor.png?size=100x100&set=set1", "Business Development", "hupstone1b@bloglines.com", "Harriott", null, "Upstone" },
                    { 49, "https://robohash.org/quaevelitoccaecati.png?size=100x100&set=set1", "Marketing", "cesler1c@reddit.com", "Cloe", null, "Esler" },
                    { 50, "https://robohash.org/cumqueipsamiste.png?size=100x100&set=set1", "Training", "mforsdike1d@skyrock.com", "Matelda", null, "Forsdike" },
                    { 51, "https://robohash.org/similiqueatqueeos.png?size=100x100&set=set1", "Services", "dtrigwell1e@canalblog.com", "Deirdre", null, "Trigwell" },
                    { 52, "https://robohash.org/impeditnesciuntomnis.png?size=100x100&set=set1", "Legal", "edemendoza1f@latimes.com", "Edgar", null, "de Mendoza" },
                    { 53, "https://robohash.org/quodeaunde.png?size=100x100&set=set1", "Legal", "nmcnicol1g@i2i.jp", "Neely", null, "McNicol" },
                    { 54, "https://robohash.org/cumcorruptimollitia.png?size=100x100&set=set1", "Human Resources", "hfinding1h@dell.com", "Henrik", null, "Finding" },
                    { 55, "https://robohash.org/voluptatumoptiominima.png?size=100x100&set=set1", "Human Resources", "nbrodest1i@surveymonkey.com", "Nevil", null, "Brodest" },
                    { 56, "https://robohash.org/delectusnumquamnihil.png?size=100x100&set=set1", "Business Development", "bmurr1j@salon.com", "Bartholemy", null, "Murr" },
                    { 57, "https://robohash.org/aliaseteaque.png?size=100x100&set=set1", "Product Management", "kscragg1k@gov.uk", "Kalil", null, "Scragg" },
                    { 58, "https://robohash.org/iustoundeperspiciatis.png?size=100x100&set=set1", "Product Management", "acavalier1l@europa.eu", "Abigail", null, "Cavalier" },
                    { 59, "https://robohash.org/inipsumnihil.png?size=100x100&set=set1", "Accounting", "zlambertciorwyn1m@merriam-webster.com", "Zacharie", null, "Lambert-Ciorwyn" },
                    { 60, "https://robohash.org/omnisprovidentaperiam.png?size=100x100&set=set1", "Training", "wsturges1n@nytimes.com", "Wallis", null, "Sturges" },
                    { 61, "https://robohash.org/perferendisminimasimilique.png?size=100x100&set=set1", "Human Resources", "msleeny1o@blogger.com", "Marion", null, "Sleeny" },
                    { 62, "https://robohash.org/debitisvoluptasenim.png?size=100x100&set=set1", "Research and Development", "brudolph1p@state.gov", "Banky", null, "Rudolph" },
                    { 63, "https://robohash.org/omnisvoluptatumquidem.png?size=100x100&set=set1", "Research and Development", "bkennermann1q@issuu.com", "Bernadine", null, "Kennermann" },
                    { 64, "https://robohash.org/quisetcupiditate.png?size=100x100&set=set1", "Product Management", "ktattershaw1r@dagondesign.com", "Kiri", null, "Tattershaw" },
                    { 65, "https://robohash.org/rerumaccusantiumea.png?size=100x100&set=set1", "Training", "scollaton1s@cbc.ca", "Shanta", null, "Collaton" },
                    { 66, "https://robohash.org/sapientedoloremquidem.png?size=100x100&set=set1", "Engineering", "csor1t@angelfire.com", "Conrade", null, "Sor" },
                    { 67, "https://robohash.org/autevenietpariatur.png?size=100x100&set=set1", "Accounting", "kmankor1u@blinklist.com", "Kristo", null, "Mankor" },
                    { 68, "https://robohash.org/atquelaborumquidem.png?size=100x100&set=set1", "Business Development", "jeacott1v@digg.com", "Janaye", null, "Eacott" },
                    { 69, "https://robohash.org/odioutsed.png?size=100x100&set=set1", "Training", "mflecknoe1w@csmonitor.com", "Myriam", null, "Flecknoe" },
                    { 70, "https://robohash.org/nihildoloremab.png?size=100x100&set=set1", "Legal", "gbumphrey1x@hp.com", "Griswold", null, "Bumphrey" },
                    { 71, "https://robohash.org/mollitiaipsaeligendi.png?size=100x100&set=set1", "Research and Development", "rshovel1y@paypal.com", "Rebeka", null, "Shovel" },
                    { 72, "https://robohash.org/remquiacorporis.png?size=100x100&set=set1", "Product Management", "sbaulk1z@google.fr", "Saidee", null, "Baulk" },
                    { 73, "https://robohash.org/nonanimibeatae.png?size=100x100&set=set1", "Research and Development", "cbogart20@eventbrite.com", "Colene", null, "Bogart" },
                    { 74, "https://robohash.org/explicaboquasiinventore.png?size=100x100&set=set1", "Human Resources", "vliff21@twitter.com", "Vera", null, "Liff" },
                    { 75, "https://robohash.org/quosdeseruntsimilique.png?size=100x100&set=set1", "Marketing", "efrantzen22@psu.edu", "Euphemia", null, "Frantzen" },
                    { 76, "https://robohash.org/velitnamnecessitatibus.png?size=100x100&set=set1", "Legal", "gfeaveryear23@slashdot.org", "Garrard", null, "Feaveryear" },
                    { 77, "https://robohash.org/corruptivelitarchitecto.png?size=100x100&set=set1", "Sales", "hyoxall24@instagram.com", "Halsey", null, "Yoxall" },
                    { 78, "https://robohash.org/quisveniamunde.png?size=100x100&set=set1", "Support", "racott25@twitter.com", "Raphael", null, "Acott" },
                    { 79, "https://robohash.org/velitestmolestiae.png?size=100x100&set=set1", "Research and Development", "djessel26@gravatar.com", "Dina", null, "Jessel" },
                    { 80, "https://robohash.org/eterrorfugiat.png?size=100x100&set=set1", "Engineering", "kscutter27@livejournal.com", "Kerry", null, "Scutter" },
                    { 81, "https://robohash.org/ullametrerum.png?size=100x100&set=set1", "Training", "gdayce28@cnbc.com", "Gianina", null, "Dayce" },
                    { 82, "https://robohash.org/doloribuscommodiincidunt.png?size=100x100&set=set1", "Accounting", "ccraisford29@cnn.com", "Claudio", null, "Craisford" },
                    { 83, "https://robohash.org/doloresmolestiasest.png?size=100x100&set=set1", "Marketing", "ofarren2a@wunderground.com", "Otis", null, "Farren" },
                    { 84, "https://robohash.org/evenietaliasvelit.png?size=100x100&set=set1", "Engineering", "gbraam2b@shinystat.com", "Gertie", null, "Braam" },
                    { 85, "https://robohash.org/sedcorruptiad.png?size=100x100&set=set1", "Business Development", "pphette2c@ibm.com", "Petr", null, "Phette" },
                    { 86, "https://robohash.org/possimusporroconsequatur.png?size=100x100&set=set1", "Legal", "wthiem2d@prweb.com", "Willow", null, "Thiem" },
                    { 87, "https://robohash.org/animiinrepellat.png?size=100x100&set=set1", "Engineering", "nhynes2e@gizmodo.com", "Nelie", null, "Hynes" },
                    { 88, "https://robohash.org/rerumvoluptatemodi.png?size=100x100&set=set1", "Services", "jberi2f@wunderground.com", "Jasmine", null, "Beri" },
                    { 89, "https://robohash.org/inciduntesterror.png?size=100x100&set=set1", "Human Resources", "sbonham2g@cbslocal.com", "Sibella", null, "Bonham" },
                    { 90, "https://robohash.org/sedatquos.png?size=100x100&set=set1", "Services", "mpiola2h@nhs.uk", "Magda", null, "Piola" },
                    { 91, "https://robohash.org/autetquisquam.png?size=100x100&set=set1", "Services", "smaudlin2i@cyberchimps.com", "Shermie", null, "Maudlin" },
                    { 92, "https://robohash.org/consecteturnihilvoluptatem.png?size=100x100&set=set1", "Research and Development", "dbarbary2j@i2i.jp", "Dulcea", null, "Barbary" },
                    { 93, "https://robohash.org/maximedoloreut.png?size=100x100&set=set1", "Business Development", "khabben2k@state.gov", "Keefer", null, "Habben" },
                    { 94, "https://robohash.org/minusidet.png?size=100x100&set=set1", "Support", "dallanby2l@mediafire.com", "Dorothy", null, "Allanby" },
                    { 95, "https://robohash.org/quiavelpossimus.png?size=100x100&set=set1", "Engineering", "tkippax2m@so-net.ne.jp", "Tobias", null, "Kippax" },
                    { 96, "https://robohash.org/laudantiumfugacupiditate.png?size=100x100&set=set1", "Support", "bgreenlies2n@fotki.com", "Burty", null, "Greenlies" },
                    { 97, "https://robohash.org/esseitaquemagni.png?size=100x100&set=set1", "Engineering", "hengall2o@google.ru", "Harrison", null, "Engall" },
                    { 98, "https://robohash.org/sintmolestiaefacere.png?size=100x100&set=set1", "Business Development", "jstimson2p@un.org", "Joaquin", null, "Stimson" },
                    { 99, "https://robohash.org/explicaboautest.png?size=100x100&set=set1", "Training", "rpetyanin2q@shareasale.com", "Retha", null, "Petyanin" },
                    { 100, "https://robohash.org/saepeconsecteturdoloremque.png?size=100x100&set=set1", "Engineering", "kwakely2r@google.de", "Kerstin", null, "Wakely" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}

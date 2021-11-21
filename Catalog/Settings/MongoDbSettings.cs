namespace Catalog.Settings
{
    public class MongoDbSettings
    {
       //public string User { get; set; }
       // public string Password { get; set; }
        public String ConnectionString
        {
            get
            {
                /* 
                 mongodb+srv://bryan:<password>@cluster0.l0ohw.mongodb.net/myFirstDatabase?retryWrites=true&w=majority
                 */
                return "mongodb+srv://bryan:Bliss-97@cluster0.l0ohw.mongodb.net/Catalog?retryWrites=true&w=majority";
            }
        }
    }
}

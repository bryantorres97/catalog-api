namespace Catalog.Settings
{
    public class MongoDbSettings
    {

        public string User {  get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public String ConnectionString
        {
            get
            {
                return $"mongodb+srv://{User}:{Password}@{Host}";
                /* 
                 mongodb+srv://bryan:<password>@cluster0.l0ohw.mongodb.net/myFirstDatabase?retryWrites=true&w=majority
                 */
            }
        }
    }
}

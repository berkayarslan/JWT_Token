using Web_Api_JWT.Enums;

namespace Web_Api_JWT.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        private Status _status = Status.Active;

        public Status Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}

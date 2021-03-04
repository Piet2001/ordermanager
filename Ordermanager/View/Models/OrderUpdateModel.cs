using System.ComponentModel.DataAnnotations;
using Ordermanager_Logic;

namespace View.Models
{
    public class OrderUpdateModel
    {
        public int Id { get; set; }
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }
    }
}


using System.Collections.Generic;
namespace MINI.Models
{
    public class StarRatingViewModel
    {
        
    }

    public class RatingAverageModel
    {
        public int RatingAverageID { get; set; }
        public string OutletID { get; set; }
        public string BusinessProcess { get; set; }
        public decimal Value { get; set; }
        public int Count { get; set; }
        public decimal Stars { get; set; }
        public string CountComments { get; set; }
        public List<RatingModel> Ratings { get; set; }
    }

    public class RatingModel
    {
        public int RatingID { get; set; }
        public string OutletID { get; set; }
        public decimal Value { get; set; }
        public int Stars { get; set; }
        public string Type { get; set; }
        public string DateTime { get; set; }
        public string CustomerComment { get; set; }
        public string DealerComment { get; set; }
    }
}
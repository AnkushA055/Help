using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatOutdoorOrder.Entities
{

    public enum CatID
    {
        None,Camping, Golf, Mountaineering, Outdoor, Personal_Accessories
    }

    public class Product 
    {

        
        public int ProductID { get ; set ; }



        [Required("Product name can't be blank.")]
        [RegExp(@"^(\w{2,40})$", "Product name should contain only 2 to 40 characters.")]
        public string ProductName { get ; set ; }

         CatID CategoryID
        {
            get; set;
        }


        [Required("Specification ID can't be blank.")]
        public int SpecificationID { get ; set ; }  //to be fetched from specification table


        [Required("Product cost price can't be blank.")]
        [RegExp(@"^[6789]\d{9}$", "Enter valid cost price.")]
        public int CostPrice { get ; set ; }



            

            public bool Available { get ; set; } // will be set by admin

        [Required("Product selling price can't be blank.")]
        [RegExp(@"^[6789]\d{9}$", "Enter Valid selling price.")]
        public int SellingPrice { get ; set; }


            public Product()
            {
                ProductID = 0;
                ProductName = null;
                CategoryID = 0;
                SpecificationID = 0;
                CostPrice = 0;
                SellingPrice = 0;
                Available = true;
            }
        
    }
}

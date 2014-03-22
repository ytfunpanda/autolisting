using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MINI.Models
{
    public class NextConfigViewModel
    {
        public int ConfigID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
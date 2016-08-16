using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SequenceCalculator.Models
{
    public class SequenceModel
    {
        
            [DisplayName("Enter Number to Generate Sequence")]
            [Required]
            [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid non negative number for generating Sequence")]
            public int InputNumber { get; set; }
            
            
            public List<int> AllNumber { get; set; }
            public List<int> AllOdd { get; set; }
            public List<int> AllEven { get; set; }
            public List<string> SpecialSeq { get; set; }
            public List<int> FibnocciSeq { get; set; }


    }
}
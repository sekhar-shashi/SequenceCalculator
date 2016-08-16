using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SequenceCalculator.Controllers
{
    public class NumericSequenceController : Controller
    {
        // GET: Sequence
        [HttpGet]
        public ActionResult Sequence()
        {
            ViewBag.Message = "<div>Welcome to our Sequence generator tool</div> <br> <h2>Getting started</h2> <br> <p> "+
           " <b>This is an online tool to generate a numeric sequence based on the   " +
            "input number as entered in the Text box below ."+
           " The following result sequence will be generated one the click of button: </b> <br>"
       + "  1) All numbers upto the entered number<br> 2)All ddd numbers upto the entered number  <br> 3) All even numbers upto the entered number <br> 4) Special sequence <br> 5) Fibonacci series upto the number entered</ p > ";

            return View();
        }
        [HttpPost]
        public ActionResult Sequence(SequenceCalculator.Models.SequenceModel m)
        {

            if (ModelState.IsValid) // checking for model state
            {
                int number = m.InputNumber;
                GenerateSequence(m); // calling function to generate sequence of integer
                GenerateOddSequence(m);// calling function to generate all odd sequence
                GenerateEvenSequence(m);// callig function to generate all even sequence
                GenerateSpecialSequence(m);// calling function to generate sequence where all multiple of 3 is replaced by C , all multiple of 5 replaced by E and all multiple of 3 & 5 replaced by Z
                GeneratefibinocciSeries(m);//calling function to generate fibnocci series

                return View(m);

            }
            else
                return RedirectToAction("Sequnece");
            
        }

        private void GenerateSequence(SequenceCalculator.Models.SequenceModel mo)
        {
            List<int> val = new List<int>();
            // looping from 0 till the input number to get sequence
            for (int i=0;i<=mo.InputNumber;i++)
            {

                val.Add(i);
            }
            mo.AllNumber = val;
        }
        private void GenerateOddSequence(SequenceCalculator.Models.SequenceModel mo)
        {
            List<int> oddVal = new List<int>();
            // checking if input is not 0 as in that case odd values would be empty
            if (mo.InputNumber == 0)
                mo.AllOdd = oddVal;
            else
            {
                // gettig odd values in range by checking against mod 2
                IEnumerable<int> oddNums =
                Enumerable.Range(1, mo.InputNumber).Where(x => x % 2 != 0); // checking odd number if not divisible by 2

                foreach (int n in oddNums)
                {
                    oddVal.Add(n);
                }


                mo.AllOdd = oddVal;
            }
        }
        private void GenerateEvenSequence(SequenceCalculator.Models.SequenceModel mo)
        {
            List<int> evenVal = new List<int>();
            // checking to see if input is not 0 or 1 in that case no even should be generated
            if (mo.InputNumber == 0 || mo.InputNumber == 1)
                mo.AllEven = evenVal;
            else
            {
                // getting even by calculating mod by 2 if == 0 
                IEnumerable<int> evenNums =
                    Enumerable.Range(2, mo.InputNumber-1).Where(x => x % 2 == 0); // checking for even number if divisible by 2

                foreach (int n in evenNums)
                {
                    evenVal.Add(n);
                }

                mo.AllEven = evenVal;
            }
        }
        private void GenerateSpecialSequence(SequenceCalculator.Models.SequenceModel mo)
        {
            List<string> val = new List<string>();
            val.Add("0");// since first position will always be 0 , so no need to check its value
            for (int i = 1; i < mo.AllNumber.Count; i++)
            {
                if (mo.AllNumber[i] % 3 == 0 && mo.AllNumber[i] % 5 == 0) // if the number in sequence is divisible by both 5 and 3 than display Z
                    val.Add("Z");
               else if (mo.AllNumber[i] % 3 == 0) // if number is divisible by 3 than display C
                    val.Add("C");
               else if (mo.AllNumber[i] % 5 == 0) // if number is divisible by 5 than display E
                    val.Add("E");
                else
                    val.Add(mo.AllNumber[i].ToString()); // all other case display the number
            }
            mo.SpecialSeq = val;
        }

        //    Fibonacci(0, 1, 1, number);

        
        public void GeneratefibinocciSeries(SequenceCalculator.Models.SequenceModel mo)
        {
            List<int> val = new List<int>();
            int number = mo.InputNumber;
            // check to see if user input is 0 or 1(in that case the fib serie will be the number itself
            if (number == 0)
                val.Add(0);
            else if (number == 1)
                val.Add(1);
            else
            {
                val.Add(0);
                val.Add(1);
            }
            int a = 0, b = 1, c = 0;
            // calculating fibnocci series
            for (int i = 2; i < number; i++)
            {
                c = a + b;
                if (c <= number)
                {
                    val.Add(c);
                }
                else
                    break;
                a = b;
                b = c;
            }
            mo.FibnocciSeq = val;
        }

        
    }
}

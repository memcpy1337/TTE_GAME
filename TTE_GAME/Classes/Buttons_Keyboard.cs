using System;
using System.Collections.Generic;
using System.Text;

namespace TTE_GAME.Classes
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Keyboard
    {
        public bool one_time { get; set; }
        
        public List<List<buttons>> buttons { get; set; }
       
    }
  
    public class buttons
    {
        public action action { get; set; }
        public string color { get; set; }
    }
    public class action
    {
        public string type { get; set; }
        public string payload { get; set; }
        public string label { get; set; }
    }
}

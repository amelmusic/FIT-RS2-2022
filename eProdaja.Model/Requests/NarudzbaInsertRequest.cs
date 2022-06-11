using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model.Requests
{
    public class NarudzbaInsertRequest
    {
        public List<NarudzbaStavkeInsertRequest> Items { get; set; } = new List<NarudzbaStavkeInsertRequest>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities.DTO
{
    public class PostEventDto
    {
        public int IdUser { get; set; }
        public int IdEventType { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<int> FurnitureIds { get; set; }
    }
}

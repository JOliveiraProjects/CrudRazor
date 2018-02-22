using Vidalink.Data;

namespace Vidalink.Models
{
    public class VidalinkBase
    {
        public VidalinkDB Context()
        {
            return new VidalinkDB();
        }
    }
}

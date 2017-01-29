using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_games_input_parser_library
{
    public interface ITextGameAction
    {
        // void GoToLocation();
        void TakeItems(List<string> items);
        void DropItems(List<string> items); 
    }
}

using System;

namespace Hangman
{
    public class GameWord
    {
        char[] letterArr = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        public List<char> usedLetterArr = new List<char>();

        public static bool HasSpecialChars(string yourString)
        {
            return yourString.Any(ch => !Char.IsLetter(ch));
        }
        public static bool WordCheck(string givenWord)
        {
            string trimmed = String.Concat(givenWord.Where(c => !Char.IsWhiteSpace(c)));
            if (HasSpecialChars(trimmed))
            {
                return false;
            }

            if (trimmed.Length <= 16 && trimmed.Length >= 4 && trimmed != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string FixedSpace(string spacedWord)
        {
            for (int ind = 0; ind < spacedWord.Length; ind++)
            {   
                if (spacedWord[spacedWord.Length - 1] == ' ')
                {
                    spacedWord = spacedWord.Remove(spacedWord.Length - 1, 1);
                }
                if (spacedWord[ind] == ' ' && spacedWord[ind + 1] == ' ')
                {
                    spacedWord = spacedWord.Remove(ind + 1, 1);
                    ind--;
                }
                if (spacedWord[0] == ' ')
                {
                    spacedWord = spacedWord.Remove(0, 1);
                }
                
            }
            return spacedWord;
        }
        public static string Underscore(string preWord)
        {
            string underCopy = "";
            for (int ind = 0; ind < preWord.Length; ind++)
            {
                if (preWord[ind] != ' ')
                {
                    underCopy += "_";
                }
                else
                {
                    underCopy += " ";
                }
            }
            return underCopy;
        }
        public static void HangedMan(int playerGuesses)
        {
            switch (playerGuesses)
            {
                case 5:
                    Console.WriteLine(" _________");
                    Console.WriteLine("|         |");
                    Console.WriteLine("|         |");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine(@"|");
                    Console.WriteLine("|");
                    Console.WriteLine(@"|");
                    Console.WriteLine("|");
                    break;
                case 4:
                    Console.WriteLine(" _________");
                    Console.WriteLine("|         |");
                    Console.WriteLine("|         |");
                    Console.WriteLine("|         O");
                    Console.WriteLine("|");
                    Console.WriteLine(@"|");
                    Console.WriteLine("|");
                    Console.WriteLine(@"|");
                    Console.WriteLine("|");
                    break;

                case 3:
                    Console.WriteLine(" _________");
                    Console.WriteLine("|         |");
                    Console.WriteLine("|         |");
                    Console.WriteLine("|         O");
                    Console.WriteLine("|         |");
                    Console.WriteLine(@"|");
                    Console.WriteLine("|");
                    Console.WriteLine(@"|");
                    Console.WriteLine("|");
                    break;

                case 2:
                    Console.WriteLine(" _________");
                    Console.WriteLine("|         |");
                    Console.WriteLine("|         |");
                    Console.WriteLine("|         O");
                    Console.WriteLine("|         |");
                    Console.WriteLine(@"|        / \ ");
                    Console.WriteLine("|");
                    Console.WriteLine(@"|");
                    Console.WriteLine("|");
                    break;

                case 1:
                    Console.WriteLine(" _________");
                    Console.WriteLine("|         |");
                    Console.WriteLine("|         |");
                    Console.WriteLine("|         O");
                    Console.WriteLine("|         |");
                    Console.WriteLine(@"|        / \ ");
                    Console.WriteLine("|         |");
                    Console.WriteLine(@"|");
                    Console.WriteLine("|");
                    break;

                case 0:
                    Console.WriteLine(" _________");
                    Console.WriteLine("|         |");
                    Console.WriteLine("|         |");
                    Console.WriteLine("|         O");
                    Console.WriteLine("|         |");
                    Console.WriteLine(@"|        / \ ");
                    Console.WriteLine("|         |");
                    Console.WriteLine(@"|        / \ ");
                    Console.WriteLine("|");
                    break;
            }
        }
        public void AvailableLetters(char playerInput)
        {
            if (letterArr.Contains(playerInput))
            {

                int ind = Array.IndexOf(letterArr, playerInput);
                usedLetterArr.Add(playerInput);
                usedLetterArr.Sort();
                letterArr = letterArr.Where((letter, index) => index != ind).ToArray();

            }
            Console.WriteLine("Nn't used letters: \n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0}", string.Join(" ", letterArr));
            Console.ResetColor();
            Console.WriteLine("\nUsed letters: \n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}", string.Join(" ", usedLetterArr));
            Console.ResetColor();
            Console.WriteLine();
        }
        public static void Animation()
        {
            Console.WriteLine(@"c::'.  .......            ....',''..'''......';;;;;,,,,,,'.              ..,:::::::;;,,,,,,'..    ..
llc:'      .. ..       ...',;:ccc:,',,;;;,;;,...'''',;;;,.            ..,;;;;;:::;;;;:::;;::;,.....,
llcc,.   ...',;,.   ..',''',,;::;;;;;,;::;;;::::;;;,,'..             .',,,;;::::;,;::c:;,;:::::;;'..
llc:'  ..;:ccc;...';;;;;:::;::::::ccc::cll:,,:cc:;,,..               ...',,,;;;::::ccc:;,;:c::::::,'
llc,.  ':lcc,.. .,:c:::c::;,'......';::;:cc::::;,...               ......,;;;;;;;;;;:::;;::c::::;:::
;:,.  .;:;,..  ...........          ....',;;;;'.               ..',;,,,,,;;:::::;;,,,,,,;;:::::;;:::
:;.  .';'..                                                 ..,;;::::;'',::;;;;;;;;,,''',,,,,;::::::
,.                                                       ..,,,;::cccc:;,,,;;:;,',,,,;;;;::;,,;;;;;::
.                                                      .';:::;;;::::;;,;,''',,,,,,;:::;;::::;;;,,,,,
                                                    ..,;::::::;,,,;;;;;;;;,,',;;,,,;;;;:::::::::;,,,
                ...''''............             ...';;::::::::::;:::::::::::;;;;;;;:;;:::::::::;,',;
             ..;:cccclllccccccc::::;,'.......',,'';;::::::::::::::::::::::::::;;;;;:::::::::;;;;;;;;
            .';:;,''';;;;:::::;,:cccccc:;:::::::'';:::::::::::::::::::::::::;;;;;;;;;;;;;;;;;;;;;;;;
            ....  ....'';;;;;,..,clccc:;;:c:::::'';;::::::::::::::::;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
           .,,'...... ..'''',;,',;::;;;;:c::::::'.';::::::;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
           .';;,,'''..',,;;;:;;;;'.',;:cc::::::;'.',:::;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,
            ...''',:cc:::ccc:;;::;'.';::;;;;:::;,'',;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;,;;,,,,,,,,,,,,,,,
       ..',..   ..,:c:::cc::c:::::;;;;;,,;;::;;;,.',;;;;;;;;;;;;;;;;,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
.'''....,;cc;'.  .'cc:,,,,;::c:;;:::::::::::;;;;,..,;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,,,,,,,,,,,,,,,,,,,
llcc:'.':ccccc,..  .';;:cc:::c:::::::::::::;;;;;,..,;;;;;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,,,,,,,,,,,,,,,
cllll:'.:llool:;;'.  .';cc::;;;:ccc:::::::::::::,..,;;:;;;;;;;;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,,,,,,,,,
:;:lool,'clllcclc:,'....',;;;::;;:c:ccccc:::::::;..'::::::::;:::::ccccccccccc::::;;;;;,,,,,,,,,,,,,,
:cclodd:';lc:coool:;;,.  .,:ccc:,;:cccccc:::cccc:'.,cccccc::::ccclllllolllllllccc:::;;;;;;;;;;;;;;::
odol:lo:':doclddddoc:c:'....,;;;,';cllllcc:cclll:,.,ccccccllllllllooooooooooooolllccc::::::::cccclll
kxollll:',lollooodddlcoo:,.. ...';:ccllccllllollc;';lolloooddddddddddddddddxxxxxddoolllllllllooooddd
dxdlodol:'':lloxxxxxdccodol:;,,;;cloolllooooooodl;':odoodddxxxxkkkxxxxxkkkkkkkkkkkxxddooooooodddddxx
olllodddol:,':oxxxxxdoclddddddolooodddoollooodddo:,:dddddxxxxkkkkkkkkkkkxxkkkkkkkkxxxdddddddddddddxx
xdoodoodoll:';oddxxxddlcldddxdoodxxxxxxddllooolol;,:dxxxxxkkkkkkkkkkkkkxxxxkkkkkkxxxxxxxxxxxdddddddd
dkkkxdodddo;'cdddddodddoclddxdodxxxxxxxxxxddddolc;':oxxxxxxxxxxxkkkkkkkkkkkxkkxxxxxxxxxxdddddddddooo
odxxxxxxxxl,;ldddoodxxxxlcodolldxxdddddooodxxxxdo:,;oxxxxxxxxxxkkkkkkkkkkkxxxxxxxxxxxddddddooooooool
xddddxxxxd:,cdxxxxxxxxxxdcccccodddddoollcloddddddc,;oxxxxxxxxkkkkkkkkkkkkxxxxddddddddddddoooolllllll
xxxxxxdxxdc;lddddddddddddl;,;ccllllcclllldxxxxxxxl;:okkkkkkkkkkkkkkkkkkkxxxxdddddddddoooooolllllllll
ddooolloooooooooooddddoodddxxxxxxooxxkOOOOkkxddxxl::oxxddddddddddddxxxxkkxddooooollllllllllccccccc::
xxddoooooooooodddddddddddddxxxxxxddxkkkkkkkkkxxxxl:;cddddoooodddxxxxxxxxdddooooollllllllccccc:::::::
kkxxddddddddddddddddddddddddddxddxxxxxxxkkxxxddddc;;coooooodddxkO0Okxdoooooooooolllcccccc:::::::::::
Okkkxxxxxxxdddddddddddddddxxxxxdxxxxxxxxxdddddooo:,'',:oddddxkO0XXX0xddooooooolllcccccc::::::::::::;
OOOOkkxxdddddddddddoooodddxkkkxddxdddddddoooooodd:...,ldxxkkO0KXXX0kxdooooooolllcccccc::::::::::::::
0KKK0OkxddoooooooooooooddxkOOOkkxxxdddddddxxkkkxd;..'okkkO0000000Okxdddddddoolllcccc::::::::::ccclll
XXNNXKOkdoooooollloooddxkOKKXKK000OOkkkOO0KKK00Ox;..;dl;,;cdO00Okkkxxkkkkkxdddooollcccc::ccclloooddd
NNWWWNXOxdddoddddddxxxkO0KXNNNNNNNXXXXXNNNNNNNXX0c....     .;kK0OOkkkkkkkkkkxxxxddddooooooddxxxkkkkO
WWWWWWWXK0OOOOOOOO000KKXXNNWWWWWNNNNNNNNNWNNNNWWXl.         .lKXKK00000000000OOOkkkkkkOOO00000000000
WWWWWWNXXKKKKKKKKKKKKKXXNNNNNNNNNNNNNNNNNNNXXXKkl.          .oKKKKKKKKKKKKKKK00OOOOOO00KKKKKKKK0000O
WWWNNXKK00000000000000KKXXXXXXXKKKKKKKKKKKK0kl,.           .l0K0000000OOO000OOOOOOOOOOOO00OOOOOOOkkk
XXKK00OOOOOOOOOOOOO000000KK00000O000000OOOd:.              ,kKKK000OOOOOkkkkkkkkkkkkkkkkkkkkkkkkkkkk
00OOOOOOkkkkkkkkOO0000000000OOOkOOOOOO0Okc.                .lO000000OOOOOOkkkxxkkkxxxxkkkkkkxxxxxxxk
0OOOOOOOkkkkkkkkkOOOOOOOOOOOkkkkkkkOkOOx:.                  ckOOOOOOOOOOOOkkkkkkkkxxxxxxxxxxxddddxxk
OOOOOOkkkkkkkkkkkkkOOOOOOOOkkkkkkkkkkkx:.                  .ckkkkkkkkkkkkkkkkkxxxxdddddxddddddddxxxx
OOOOOOkkkkkkkkkkkkkkOOOOOOkkkkkkkkkkkkl.                    ;dxxdddddddxxxxxxxxxxxxdddxdddxxxxxxxxxd
000000OOOOOOkkkkkkkkkOOOOOOOOOOkkkkkkx,                    .;oddddddddddxxxxxxxxxxxxxxxxxddddddddddo
OOOOOOOkkkkxxxkkkkkkkOOOOOOOOOOOOOkkkd,                   'cdxxxxxxxxxxxkkxxxxxxxxxxddddddddoooooooo
dxxkkxxxxxxxkkkOkkkkkkkkOOOOOO000OOkkx:                  .cxkkkkkkkkkkkkkkkxxxdddddddddddddddddooodd
ddkkkkkkkOkkOO0OOOkkkkkkOOOOOOOOOOOOkkdc:c,              .;xOOOkkkkkkkkkkkkkkkkkkkkkkkkkkkkkxxxxxxxx
xkkOkkkOOOkkkOOkkkkkOOOOOOOOOkkkOOOkkxxxkx;               'dkOOkkkkkkkkkOOOOkkkkkkkkkkkkkkkkkkkkkkkx
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxkx;              .:xkOOOOOOOOkkkkkkxxxddddddddddddddxxxxxxxx
oodddddddddddddddddoooooddddddddddddddxxkx;             .:dxkkkkkkxxxxxxxxddddoooooooooooooooooooooo
llooooooooooooooooooollloooooooooooooddxkx;             .loodddddooooooooooooooollllllllllllllllllll
llloooooooooolloooooolllloolooollooooodxkd,             ,lllllllllllllllllllllllllcccccccccccccccccc
lloooolooooooooloooooolllllloooooooooodxkx;            .;llllllllllllollllooooooolllllllllllllllllll
ooooooloooooooollooooooolloooooooooooddxxd;            .:llllllllllooooooooooooooooooooollllllllllcc
ooooollloooddoolllooooolllllllooooooooodxd;            ,cllllllllllllllllllllllllllccccccccccccccccc
lllllcclloooooollllllllcccccclloooollloodo;           .;llllllllllllllcccccccccccccccccccccccccccccc
c:::::cllollllllolccc::ccccccllllllllcccc:'           .;clllccccccccccccccccccccc::cc::ccccc::::::::
lcc:ccccc:;;,;;:lc::c:;;cc:;;:c:::;;:;,''..           .,;;,;,,,,'''.'',,;;;;;,,'''',,'',;;,,''...'..
,'..............''..'....................             .........................   ...   ......  ..  
. .....................................                      ................... ...         .  .   
........................................                 .........    ......... . ..                
.........................................                    ..        ......     .                 
........................................                     .....     ......  .  ..                
........................................                     ......   .......  .                    
..................................  ....       .              .  ..     ...... .   .                
................................... ....               .....     ...................................
..........................................            ..............................................
............''...............................   ..   ..''''.'''''''''..............................'
............''........................................'''''..'''''''''..............................
.......................................................''...........................................
....................................................................................................
....................................................................................................");
System.Threading.Thread.Sleep(500);
Console.Clear();
Console.WriteLine(@"c::'.  .......            ....',''..'''......';;;;;,,,,,,'.              ..,:::::::;;,,,,,,'..    ..
llc:'      .. ..       ...',;:ccc:,',,;;;,;;,...'''',;;;,.            ..,;;;;;:::;;;:::;;::;,.....,
llcc,.   ...',;,.   ..',''',,;::;;;;;,;::;;;::::;;;,,'..             .',,,;;::::;,;::c:;,;:::::;;'..
llc:'  ..;:ccc;...';;;;;:::;::::::ccc::cll:,,:cc:;,,..               ...',,,;;;::::ccc:;,;:c::::::,'
llc,.  ':lcc,.. .,:c:::c::;,'......';::;:cc::::;,...               ......,;;;;;;;;;;:::;;::c::::;:::
;:,.  .;:;,..  ...........          ....',;;;;'.               ..',;,,,,,;;:::::;;,,,,,,;;:::::;;:::
:;.  .';'..                                                 ..,;;::::;'',::;;;;;;;;,,''',,,,,;::::::
,.                                                       ..,,,;::cccc:;,,,;;:;,',,,,;;;;::;,,;;;;;::
.                                                      .';:::;;;::::;;,;,''',,,,,,;:::;;::::;;;,,,,,
                                                    ..,;::::::;,,,;;;;;;;;,,',;;,,,;;;;:::::::::;,,,
                ...''''............             ...';;::::::::::;:::::::::::;;;;;;;:;;:::::::::;,',;
             ..;:cccclllccccccc::::;,'.......',,'';;::::::::::::::::::::::::::;;;;;:::::::::;;;;;;;;
            .';:;,''';;;;:::::;,:cccccc:;:::::::'';:::::::::::::::::::::::::;;;;;;;;;;;;;;;;;;;;;;;;
            ....  ....'';;;;;,..,clccc:;;:c:::::'';;::::::::::::::::;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
           .,,'...... ..'''',;,',;::;;;;:c::::::'.';::::::;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
           .';;,,'''..',,;;;:;;;;'.',;:cc::::::;'.',:::;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,
            ...''',:cc:::ccc:;;::;'.';::;;;;:::;,'',;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;,;;,,,,,,,,,,,,,,,
       ..',..   ..,:c:::cc::c:::::;;;;;,,;;::;;;,.',;;;;;;;;;;;;;;;;,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
.'''....,;cc;'.  .'cc:,,,,;::c:;;:::::::::::;;;;,..,;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,,,,,,,,,,,,,,,,,,,
llcc:'.':ccccc,..  .';;:cc:::c:::::::::::::;;;;;,..,;;;;;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,,,,,,,,,,,,,,,
cllll:'.:llool:;;'.  .';cc::;;;:ccc:::::::::::::,..,;;:;;;;;;;;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,,,,,,,,,
:;:lool,'clllcclc:,'....',;;;::;;:c:ccccc:::::::;..'::::::::;:::::ccccccccccc::::;;;;;,,,,,,,,,,,,,,
:cclodd:';lc:coool:;;,.  .,:ccc:,;:cccccc:::cccc:'.,cccccc::::ccclllllolllllllccc:::;;;;;;;;;;;;;;::
odol:lo:':doclddddoc:c:'....,;;;,';cllllcc:cclll:,.,ccccccllllllllooooooooooooolllccc::::::::cccclll
kxollll:',lollooodddlcoo:,.. ...';:ccllccllllollc;';lolloooddddddddddddddddxxxxxddoolllllllllooooddd
dxdlodol:'':lloxxxxxdccodol:;,,;;cloolllooooooodl;':odoodddxxxxkkkxxxxxkkkkkkkkkkkxxddooooooodddddxx
olllodddol:,':oxxxxxdoclddddddolooodddoollooodddo:,:dddddxxxxkkkkkkkkkkkxxkkkkkkkkxxxdddddddddddddxx
xdoodoodoll:';oddxxxddlcldddxdoodxxxxxxddllooolol;,:dxxxxxkkkkkkkkkkkkkxxxxkkkkkkxxxxxxxxxxxdddddddd
dkkkxdodddo;'cdddddodddoclddxdodxxxxxxxxxxddddolc;':oxxxxxxxxxxxkkkkkkkkkkkxkkxxxxxxxxxxdddddddddooo
odxxxxxxxxl,;ldddoodxxxxlcodolldxxdddddooodxxxxdo:,;oxxxxxxxxxxkkkkkkkkkkkxxxxxxxxxxxddddddooooooool
xddddxxxxd:,cdxxxxxxxxxxdcccccodddddoollcloddddddc,;oxxxxxxxxkkkkkkkkkkkkxxxxddddddddddddoooolllllll
xxxxxxdxxdc;lddddddddddddl;,;ccllllcclllldxxxxxxxl;:okkkkkkkkkkkkkkkkkkkxxxxdddddddddoooooolllllllll
ddooolloooooooooooddddoodddxxxxxxooxxkOOOOkkxddxxl::oxxddddddddddddxxxxkkxddooooollllllllllccccccc::
xxddoooooooooodddddddddddddxxxxxddxkkkkkkkkkxxxxl:;cddddoooodddxxxxxxxxdddooooollllllllccccc:::::::
kkxxddddddddddddddddddddddddddxdxxxxxxxkkxxxddddc;;coooooodddxkO0Okxdoooooooooolllcccccc:::::::::::
Okkkxxxxxxxdddddddddddddddxxxxdxxxxxxxxxdddddooo:,'',:oddddxkO0XXX0xddooooooolllcccccc::::::::::::;
OOOOkkxxdddddddddddoooodddxkkxddxdddddddoooooodd:...,ldxxkkO0KXXX0kxdooooooolllcccccc::::::::::::::
0KKK0OkxddoooooooooooooddxkOOkkxxxdddddddxxkkkxd;..'okkkO0000000Okxdddddddoolllcccc::::::::::ccclll
XXNNXKOkdoooooollloooddxOKKXKK000OOkkkOO0KKK00Ox;..;dl;,;cdO00Okkkxxkkkkkxdddooollcccc::ccclloooddd
NNWWWNXOxdddoddddddxxxkO0KXNNNNNNNXXXXXNNNNNNNXX0c....    .;kK0OOkkkkkkkkkkxxxxddddooooooddxxxkkkkO
WWWWWWWXK0OOOOOOOO000KXXNNWWWWWNNNNNNNNNWNNNNWWXl.         .lKXKK00000000000OOOkkkkkkOOO00000000000
WWWWWWNXXKKKKKKKKKKKKXXNNNNNNNNNNNNNNNNNNXXXKkl.          .oKKKKKKKKKKKKKKK00OOOOOO00KKKKKKKK0000O
WWWNNXKK0000000000000KKXXXXXXXKKKKKKKKKKK0kl,.           .l0K0000000OOO000OOOOOOOOOOOO00OOOOOOOkkk
XXKK00OOOOOOOOOOOOO00000KK0000O000000OOOd:.              ,kKKK000OOOOOkkkkkkkkkkkkkkkkkkkkkkkkkkkk
00OOOOOOkkkkkkkkO000000000OOOkOOOOOO0Okc.                .lO000000OOOOOOkkkxxkkkxxxxkkkkkkxxxxxxxk
0OOOOOOOkkkkkkkkkOOOOOOOOOkkkkkkkOkOOx:.                  ckOOOOOOOOOOOOkkkkkkkkxxxxxxxxxxxddddxxk
OOOOOOkkkkkkkkkkkkOOOOOOOkkkkkkkkkkkx:.                  .ckkkkkkkkkkkkkkkkkxxxxdddddxddddddddxxxx
OOOOOOkkkkkkkkkkkkkOOOOOkkkkkkkkkkkkl.                    ;dxxdddddddxxxxxxxxxxxxdddxdddxxxxxxxxxd
000000OOOOOOkkkkkkkkOOOOOOOOOkkkkkkx,                    .;oddddddddddxxxxxxxxxxxxxxxxxddddddddddo
OOOOOOOkkkkxxxkkkkkkOOOOOOOOOOOOkkkd,                   'cdxxxxxxxxxxxkkxxxxxxxxxxddddddddoooooooo
dxxkkxxxxxxxkkkOkkkkkkkOOOOO000OOkkx:                  .cxkkkkkkkkkkkkkkkxxxdddddddddddddddddooodd
ddkkkkkkkOkkOO0OOkkkkkkOOOOOOOOOOOkkdc:c,              .;xOOOkkkkkkkkkkkkkkkkkkkkkkkkkkkkkxxxxxxxx
xkkOkkkOOOkkkOOkkkkOOOOOOOOkkkOOOkkxxxkx;               'dkOOkkkkkkkkkOOOOkkkkkkkkkkkkkkkkkkkkkkkx
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxkx;              .:xkOOOOOOOOkkkkkkxxxddddddddddddddxxxxxxxx
ooddddddddddddddddooooodddddddddddddxxkx;             .:dxkkkkkkxxxxxxxxddddoooooooooooooooooooooo
lloooooooooooooooooolllooooooooooooddxkx;             .loodddddooooooooooooooollllllllllllllllllll
llloooooooooollooooollllooloollooooodxkd,             ,lllllllllllllllllllllllllcccccccccccccccccc
llooooloooooooolooooollllllooooooooodxkx;            .;llllllllllllollllooooooolllllllllllllllllll
ooooooloooooooolloooooollooooooooooddxxd;            .:llllllllllooooooooooooooooooooollllllllllcc
ooooollloooddoollooooollllllloooooooodxd;            ,cllllllllllllllllllllllllllccccccccccccccccc
lllllcclloooooolllllllccccccllooollloodo;           .;llllllllllllllcccccccccccccccccccccccccccccc
c:::::cllolllllolccc::cccccclllllllcccc:'           .;clllccccccccccccccccccccc::cc::ccccc::::::::
lcc:ccccc:;;,;:lc::c:;;cc:;:c::;;:;,''..           .,;;,;,,,,'''.'',,;;;;;,,'''',,'',;;,,''...'..
,'.............''..'...................             .........................   ...   ......  ..  
. ...................................                      ................... ...         .  .   
......................................                 ..........    ......... . ..                
.......................................                    ...        ......     .                 
......................................                    ......     ......  .  ..                
......................................                     .......   .......  .                    
................................  ....       .              ..  ..     ...... .   .                
................................. ....               .....     ...................................
........................................            ..............................................
...........''..............................   ..   ..''''.'''''''''..............................'
............''........................................'''''..'''''''''..............................
.......................................................''...........................................
....................................................................................................
....................................................................................................");
System.Threading.Thread.Sleep(500);
Console.Clear();
Console.WriteLine(@"c::'.  .......            ....',''..'''......';;;;;,,,,,,'.              ..,:::::::;;,,,,,,'..    ..
llc:'      .. ..       ...',;:ccc:,',,;;;,;;,...'''',;;;,.            ..,;;;;;:::;;;;:::;;::;,.....,
llcc,.   ...',;,.   ..',''',,;::;;;;;,;::;;;::::;;;,,'..             .',,,;;::::;,;::c:;,;:::::;;'..
llc:'  ..;:ccc;...';;;;;:::;::::::ccc::cll:,,:cc:;,,..               ...',,,;;;::::ccc:;,;:c::::::,'
llc,.  ':lcc,.. .,:c:::c::;,'......';::;:cc::::;,...               ......,;;;;;;;;;;:::;;::c::::;:::
;:,.  .;:;,..  ...........          ....',;;;;'.               ..',;,,,,,;;:::::;;,,,,,,;;:::::;;:::
:;.  .';'..                                                 ..,;;::::;'',::;;;;;;;;,,''',,,,,;::::::
,.                                                       ..,,,;::cccc:;,,,;;:;,',,,,;;;;::;,,;;;;;::
.                                                      .';:::;;;::::;;,;,''',,,,,,;:::;;::::;;;,,,,,
                                                    ..,;::::::;,,,;;;;;;;;,,',;;,,,;;;;:::::::::;,,,
                ...''''............             ...';;::::::::::;:::::::::::;;;;;;;:;;:::::::::;,',;
             ..;:cccclllccccccc::::;,'.......',,'';;::::::::::::::::::::::::::;;;;;:::::::::;;;;;;;;
            .';:;,''';;;;:::::;,:cccccc:;:::::::'';:::::::::::::::::::::::::;;;;;;;;;;;;;;;;;;;;;;;;
            ....  ....'';;;;;,..,clccc:;;:c:::::'';;::::::::::::::::;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
           .,,'...... ..'''',;,',;::;;;;:c::::::'.';::::::;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
           .';;,,'''..',,;;;:;;;;'.',;:cc::::::;'.',:::;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,
            ...''',:cc:::ccc:;;::;'.';::;;;;:::;,'',;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;,;;,,,,,,,,,,,,,,,
       ..',..   ..,:c:::cc::c:::::;;;;;,,;;::;;;,.',;;;;;;;;;;;;;;;;,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
.'''....,;cc;'.  .'cc:,,,,;::c:;;:::::::::::;;;;,..,;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,,,,,,,,,,,,,,,,,,,
llcc:'.':ccccc,..  .';;:cc:::c:::::::::::::;;;;;,..,;;;;;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,,,,,,,,,,,,,,,
cllll:'.:llool:;;'.  .';cc::;;;:ccc:::::::::::::,..,;;:;;;;;;;;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,,,,,,,,,
:;:lool,'clllcclc:,'....',;;;::;;:c:ccccc:::::::;..'::::::::;:::::ccccccccccc::::;;;;;,,,,,,,,,,,,,,
:cclodd:';lc:coool:;;,.  .,:ccc:,;:cccccc:::cccc:'.,cccccc::::ccclllllolllllllccc:::;;;;;;;;;;;;;;::
odol:lo:':doclddddoc:c:'....,;;;,';cllllcc:cclll:,.,ccccccllllllllooooooooooooolllccc::::::::cccclll
kxollll:',lollooodddlcoo:,.. ...';:ccllccllllollc;';lolloooddddddddddddddddxxxxxddoolllllllllooooddd
dxdlodol:'':lloxxxxxdccodol:;,,;;cloolllooooooodl;':odoodddxxxxkkkxxxxxkkkkkkkkkkkxxddooooooodddddxx
olllodddol:,':oxxxxxdoclddddddolooodddoollooodddo:,:dddddxxxxkkkkkkkkkkkxxkkkkkkkkxxxdddddddddddddxx
xdoodoodoll:';oddxxxddlcldddxdoodxxxxxxddllooolol;,:dxxxxxkkkkkkkkkkkkkxxxxkkkkkkxxxxxxxxxxxdddddddd
dkkkxdodddo;'cdddddodddoclddxdodxxxxxxxxxxddddolc;':oxxxxxxxxxxxkkkkkkkkkkkxkkxxxxxxxxxxdddddddddooo
odxxxxxxxxl,;ldddoodxxxxlcodolldxxdddddooodxxxxdo:,;oxxxxxxxxxxkkkkkkkkkkkxxxxxxxxxxxddddddooooooool
xddddxxxxd:,cdxxxxxxxxxxdcccccodddddoollcloddddddc,;oxxxxxxxxkkkkkkkkkkkkxxxxddddddddddddoooolllllll
xxxxxxdxxdc;lddddddddddddl;,;ccllllcclllldxxxxxxxl;:okkkkkkkkkkkkkkkkkkkxxxxdddddddddoooooolllllllll
ddooolloooooooooooddddoodddxxxxxxooxxkOOOOkkxddxxl::oxxddddddddddddxxxxkkxddooooollllllllllccccccc::
xxddoooooooooodddddddddddddxxxxxxddxkkkkkkkkkxxxxl:;cddddoooodddxxxxxxxxdddooooollllllllccccc:::::::
kkxxddddddddddddddddddddddddddxddxxxxxxxkkxxxddddc;;coooooodddxkO0Okxdoooooooooolllcccccc:::::::::::
Okkkxxxxxxxdddddddddddddddxxxxxdxxxxxxxxxdddddooo:,'',:oddddxkO0XXX0xddooooooolllcccccc::::::::::::;
OOOOkkxxdddddddddddoooodddxkkkxddxdddddddoooooodd:...,ldxxkkO0KXXX0kxdooooooolllcccccc::::::::::::::
0KKK0OkxddoooooooooooooddxkOOOkkxxxdddddddxxkkkxd;..'okkkO0000000Okxdddddddoolllcccc::::::::::ccclll
XXNNXKOkdoooooollloooddxkOKKXKK000OOkkkOO0KKK00Ox;..;dl;,;cdO00Okkkxxkkkkkxdddooollcccc::ccclloooddd
NNWWWNXOxdddoddddddxxxkO0KXNNNNNNNXXXXXNNNNNNNXX0c....     .;kK0OOkkkkkkkkkkxxxxddddooooooddxxxkkkkO
WWWWWWWXK0OOOOOOOO000KKXXNNWWWWWNNNNNNNNNWNNNNWWXl.         .lKXKK00000000000OOOkkkkkkOOO00000000000
WWWWWWNXXKKKKKKKKKKKKKXXNNNNNNNNNNNNNNNNNNNXXXKkl.          .oKKKKKKKKKKKKKKK00OOOOOO00KKKKKKKK0000O
WWWNNXKK00000000000000KKXXXXXXXKKKKKKKKKKKK0kl,.           .l0K0000000OOO000OOOOOOOOOOOO00OOOOOOOkkk
XXKK00OOOOOOOOOOOOO000000KK00000O000000OOOd:.              ,kKKK000OOOOOkkkkkkkkkkkkkkkkkkkkkkkkkkkk
00OOOOOOkkkkkkkkOO0000000000OOOkOOOOOO0Okc.                .lO000000OOOOOOkkkxxkkkxxxxkkkkkkxxxxxxxk
0OOOOOOOkkkkkkkkkOOOOOOOOOOOkkkkkkkOkOOx:.                  ckOOOOOOOOOOOOkkkkkkkkxxxxxxxxxxxddddxxk
OOOOOOkkkkkkkkkkkkkOOOOOOOOkkkkkkkkkkkx:.                  .ckkkkkkkkkkkkkkkkkxxxxdddddxddddddddxxxx
OOOOOOkkkkkkkkkkkkkkOOOOOOkkkkkkkkkkkkl.                    ;dxxdddddddxxxxxxxxxxxxdddxdddxxxxxxxxxd
000000OOOOOOkkkkkkkkkOOOOOOOOOOkkkkkkx,                    .;oddddddddddxxxxxxxxxxxxxxxxxddddddddddo
OOOOOOOkkkkxxxkkkkkkkOOOOOOOOOOOOOkkkd,                   'cdxxxxxxxxxxxkkxxxxxxxxxxddddddddoooooooo
dxxkkxxxxxxxkkkOkkkkkkkkOOOOOO000OOkkx:                  .cxkkkkkkkkkkkkkkkxxxdddddddddddddddddooodd
ddkkkkkkkOkkOO0OOOkkkkkkOOOOOOOOOOOOkkdc:c,              .;xOOOkkkkkkkkkkkkkkkkkkkkkkkkkkkkkxxxxxxxx
xkkOkkkOOOkkkOOkkkkkOOOOOOOOOkkkOOOkkxxxkx;               'dkOOkkkkkkkkkOOOOkkkkkkkkkkkkkkkkkkkkkkkx
xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxkx;              .:xkOOOOOOOOkkkkkkxxxddddddddddddddxxxxxxxx
oodddddddddddddddddoooooddddddddddddddxxkx;             .:dxkkkkkkxxxxxxxxddddoooooooooooooooooooooo
llooooooooooooooooooollloooooooooooooddxkx;             .loodddddooooooooooooooollllllllllllllllllll
llloooooooooolloooooolllloolooollooooodxkd,             ,lllllllllllllllllllllllllcccccccccccccccccc
lloooolooooooooloooooolllllloooooooooodxkx;            .;llllllllllllollllooooooolllllllllllllllllll
ooooooloooooooollooooooolloooooooooooddxxd;            .:llllllllllooooooooooooooooooooollllllllllcc
ooooollloooddoolllooooolllllllooooooooodxd;            ,cllllllllllllllllllllllllllccccccccccccccccc
lllllcclloooooollllllllcccccclloooollloodo;           .;llllllllllllllcccccccccccccccccccccccccccccc
c:::::cllollllllolccc::ccccccllllllllcccc:'           .;clllccccccccccccccccccccc::cc::ccccc::::::::
lcc:ccccc:;;,;;:lc::c:;;cc:;;:c:::;;:;,''..           .,;;,;,,,,'''.'',,;;;;;,,'''',,'',;;,,''...'..
,'..............''..'....................             .........................   ...   ......  ..  
. .....................................                      ................... ...         .  .   
........................................                 .........    ......... . ..                
.........................................                    ..        ......     .                 
........................................                     .....     ......  .  ..                
........................................                     ......   .......  .                    
..................................  ....       .              .  ..     ...... .   .                
................................... ....               .....     ...................................
..........................................            ..............................................
............''...............................   ..   ..''''.'''''''''..............................'
............''........................................'''''..'''''''''..............................
.......................................................''...........................................
....................................................................................................
....................................................................................................");
System.Threading.Thread.Sleep(500);
Console.Clear();
Console.WriteLine(@"c::'.  .......            ....',''..'''......';;;;;,,,,,,'.              ..,:::::::;;,,,,,,'..    ..
llc:'      .. ..       ...',;:ccc:,',,;;;,;;,...'''',;;;,.            ..,;;;;;:::;;;;:::;;::;,.....,
llcc,.   ...',;,.   ..',''',,;::;;;;;,;::;;;::::;;;,,'..             .',,,;;::::;,;::c:;,;:::::;;'..
llc:'  ..;:ccc;...';;;;;:::;::::::ccc::cll:,,:cc:;,,..               ...',,,;;;::::ccc:;,;:c::::::,'
llc,.  ':lcc,.. .,:c:::c::;,'......';::;:cc::::;,...               ......,;;;;;;;;;;:::;;::c::::;:::
;:,.  .;:;,..  ...........          ....',;;;;'.               ..',;,,,,,;;:::::;;,,,,,,;;:::::;;:::
:;.  .';'..                                                 ..,;;::::;'',::;;;;;;;;,,''',,,,,;::::::
,.                                                       ..,,,;::cccc:;,,,;;:;,',,,,;;;;::;,,;;;;;::
.                                                      .';:::;;;::::;;,;,''',,,,,,;:::;;::::;;;,,,,,
                                                    ..,;::::::;,,,;;;;;;;;,,',;;,,,;;;;:::::::::;,,,
                ...''''............             ...';;::::::::::;:::::::::::;;;;;;;:;;:::::::::;,',;
             ..;:cccclllccccccc::::;,'.......',,'';;::::::::::::::::::::::::::;;;;;:::::::::;;;;;;;;
            .';:;,''';;;;:::::;,:cccccc:;:::::::'';:::::::::::::::::::::::::;;;;;;;;;;;;;;;;;;;;;;;;
            ....  ....'';;;;;,..,clccc:;;:c:::::'';;::::::::::::::::;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
           .,,'...... ..'''',;,',;::;;;;:c::::::'.';::::::;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
           .';;,,'''..',,;;;:;;;;'.',;:cc::::::;'.',:::;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,
            ...''',:cc:::ccc:;;::;'.';::;;;;:::;,'',;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;,;;,,,,,,,,,,,,,,,
       ..',..   ..,:c:::cc::c:::::;;;;;,,;;::;;;,.',;;;;;;;;;;;;;;;;,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
.'''....,;cc;'.  .'cc:,,,,;::c:;;:::::::::::;;;;,..,;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,,,,,,,,,,,,,,,,,,,
llcc:'.':ccccc,..  .';;:cc:::c:::::::::::::;;;;;,..,;;;;;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,,,,,,,,,,,,,,,
cllll:'.:llool:;;'.  .';cc::;;;:ccc:::::::::::::,..,;;:;;;;;;;;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,,,,,,,,,
:;:lool,'clllcclc:,'....',;;;::;;:c:ccccc:::::::;..'::::::::;:::::ccccccccccc::::;;;;;,,,,,,,,,,,,,,
:cclodd:';lc:coool:;;,.  .,:ccc:,;:cccccc:::cccc:'.,cccccc::::ccclllllolllllllccc:::;;;;;;;;;;;;;;::
odol:lo:':doclddddoc:c:'....,;;;,';cllllcc:cclll:,.,ccccccllllllllooooooooooooolllccc::::::::cccclll
kxollll:',lollooodddlcoo:,.. ...';:ccllccllllollc;';lolloooddddddddddddddddxxxxxddoolllllllllooooddd
dxdlodol:'':lloxxxxxdccodol:;,,;;cloolllooooooodl;':odoodddxxxxkkkxxxxxkkkkkkkkkkkxxddooooooodddddxx
olllodddol:,':oxxxxxdoclddddddolooodddoollooodddo:,:dddddxxxxkkkkkkkkkkkxxkkkkkkkkxxxdddddddddddddxx
xdoodoodoll:';oddxxxddlcldddxdoodxxxxxxddllooolol;,:dxxxxxkkkkkkkkkkkkkxxxxkkkkkkxxxxxxxxxxxdddddddd
dkkkxdodddo;'cdddddodddoclddxdodxxxxxxxxxxddddolc;':oxxxxxxxxxxxkkkkkkkkkkkxkkxxxxxxxxxxdddddddddooo
odxxxxxxxxl,;ldddoodxxxxlcodolldxxdddddooodxxxxdo:,;oxxxxxxxxxxkkkkkkkkkkkxxxxxxxxxxxddddddooooooool
xddddxxxxd:,cdxxxxxxxxxxdcccccodddddoollcloddddddc,;oxxxxxxxxkkkkkkkkkkkkxxxxddddddddddddoooolllllll
xxxxxxdxxdc;lddddddddddddl;,;ccllllcclllldxxxxxxxl;:okkkkkkkkkkkkkkkkkkkxxxxdddddddddoooooolllllllll
 ddooolloooooooooooddddoodddxxxxxxooxxkOOOOkkxddxxl::oxxddddddddddddxxxxkkxddooooollllllllllccccccc::
 xxddoooooooooodddddddddddddxxxxxxddxkkkkkkkkkxxxxl:;cddddoooodddxxxxxxxxdddooooollllllllccccc:::::::
 kkxxdddddddddddddddddddddddddddxddxxxxxxxkkxxxddddc;;coooooodddxkO0Okxdoooooooooolllcccccc:::::::::::
 Okkkxxxxxxxdddddddddddddddxxxxxxdxxxxxxxxxdddddooo:,'',:oddddxkO0XXX0xddooooooolllcccccc::::::::::::;
 OOOOkkxxdddddddddddoooodddxkkkxdddxdddddddoooooodd:...,ldxxkkO0KXXX0kxdooooooolllcccccc::::::::::::::
 0KKK0OkxddoooooooooooooddxkOOOkkxxxxdddddddxxkkkxd;..'okkkO0000000Okxdddddddoolllcccc::::::::::ccclll
 XXNNXKOkdoooooollloooddxkOKKXKK0000OOkkkOO0KKK00Ox;..;dl;,;cdO00Okkkxxkkkkkxdddooollcccc::ccclloooddd
 NNWWWNXOxdddoddddddxxxkO0KXNNNNNNNXXXXXXNNNNNNNXX0c....     .;kK0OOkkkkkkkkkkxxxxddddooooooddxxxkkkkO
 WWWWWWWXK0OOOOOOOO000KKXXNNWWWWWNNNNNNNNNNWNNNNWWXl.         .lKXKK00000000000OOOkkkkkkOOO00000000000
 WWWWWWNXXKKKKKKKKKKKKKXXNNNNNNNNNNNNNNNNNNNNXXXKkl.          .oKKKKKKKKKKKKKKK00OOOOOO00KKKKKKKK0000O
 WWWNNXKK00000000000000KKXXXXXXXKKKKKKKKKKKKK0kl,.           .l0K0000000OOO000OOOOOOOOOOOO00OOOOOOOkkk
 XXKK00OOOOOOOOOOOOO000000KK00000O0000000OOOd:.              ,kKKK000OOOOOkkkkkkkkkkkkkkkkkkkkkkkkkkkk
 00OOOOOOkkkkkkkkOO0000000000OOOkOOOOOOO0Okc.                .lO000000OOOOOOkkkxxkkkxxxxkkkkkkxxxxxxxk
 0OOOOOOOkkkkkkkkkOOOOOOOOOOOkkkkkkkkOkOOx:.                  ckOOOOOOOOOOOOkkkkkkkkxxxxxxxxxxxddddxxk
 OOOOOOkkkkkkkkkkkkkOOOOOOOOkkkkkkkkkkkkx:.                  .ckkkkkkkkkkkkkkkkkxxxxdddddxddddddddxxxx
 OOOOOOkkkkkkkkkkkkkkOOOOOOkkkkkkkkkkkkkl.                    ;dxxdddddddxxxxxxxxxxxxdddxdddxxxxxxxxxd
 000000OOOOOOkkkkkkkkkOOOOOOOOOOkkkkkkkx,                    .;oddddddddddxxxxxxxxxxxxxxxxxddddddddddo
 OOOOOOOkkkkxxxkkkkkkkOOOOOOOOOOOOOkkkkd,                   'cdxxxxxxxxxxxkkxxxxxxxxxxddddddddoooooooo
 dxxkkxxxxxxxkkkOkkkkkkkkOOOOOO000OOkkkx:                  .cxkkkkkkkkkkkkkkkxxxdddddddddddddddddooodd
 ddkkkkkkkOkkOO0OOOkkkkkkOOOOOOOOOOOOkkkdc:c,              .;xOOOkkkkkkkkkkkkkkkkkkkkkkkkkkkkkxxxxxxxx
 xkkOkkkOOOkkkOOkkkkkOOOOOOOOOkkkOOOkkxxxxkx;               'dkOOkkkkkkkkkOOOOkkkkkkkkkkkkkkkkkkkkkkkx
 xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxkx;              .:xkOOOOOOOOkkkkkkxxxddddddddddddddxxxxxxxx
 oodddddddddddddddddoooooddddddddddddddxxxkx;             .:dxkkkkkkxxxxxxxxddddoooooooooooooooooooooo
 llooooooooooooooooooollloooooooooooooddxkxx;             .loodddddooooooooooooooollllllllllllllllllll
 llloooooooooolloooooolllloolooollooooodxxkd,             ,lllllllllllllllllllllllllcccccccccccccccccc
 lloooolooooooooloooooolllllloooooooooodxkkx;            .;llllllllllllollllooooooolllllllllllllllllll
 ooooooloooooooollooooooolloooooooooooddxxdd;            .:llllllllllooooooooooooooooooooollllllllllcc
 ooooollloooddoolllooooolllllllooooooooodxdd;            ,cllllllllllllllllllllllllllccccccccccccccccc
 lllllcclloooooollllllllcccccclloooolllooodo;           .;llllllllllllllcccccccccccccccccccccccccccccc
 c:::::cllollllllolccc::ccccccllllllllccccc:'           .;clllccccccccccccccccccccc::cc::ccccc::::::::
 lcc:ccccc:;;,;;:lc::c:;;cc:;;:c:::;;:;,,''..           .,;;,;,,,,'''.'',,;;;;;,,'''',,'',;;,,''...'..
 ,'..............''..'.....................             .........................   ...   ......  ..  
 . ......................................                      ................... ...         .  .   
 .........................................                 .........    ......... . ..                
 ..........................................                    ..        ......     .                 
 .........................................                     .....     ......  .  ..                
 .........................................                     ......   .......  .                    
 ..................................  .....       .              .  ..     ...... .   .                
 ................................... .....               .....     ...................................
 ...........................................            ..............................................
 ............''................................   ..   ..''''.'''''''''..............................'
 ............''........................................'''''..'''''''''..............................
.......................................................''...........................................
....................................................................................................
....................................................................................................");
System.Threading.Thread.Sleep(500);
Console.Clear();
        }
    }
}

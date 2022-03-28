using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tic_Tac_Toe : ContentPage
    {
        string[,] tictac_board = new string[3, 3];
        bool gameOver = false;
        bool crossesWon = false;
        bool noughtsWon = false;
        public const int EOF = -1;
        public const int ONE_PLAYER = 1;
        public const int TWO_PLAYERS = 2;
        int play_mode = TWO_PLAYERS;
        bool play_easy = true;
        int which_player = ONE_PLAYER; // player 1 - starts first.
        string which_symbol = " ";
        public const int ROWS = 3;
        public const int COLS = 3;
        public const string CROSSES = "X";
        public const string NOUGHTS = "O";
        string whichsymbol = " ";

        public void OnResetButtonClicked(object sender, EventArgs e)
        {
            InitilizeBoard();
            gameOver = false;
            crossesWon = false;
            noughtsWon = false;
        }

        public void InitilizeBoard()
        {
            tictac_board[0, 0] = " ";
            tictac_board[0, 1] = " ";
            tictac_board[0, 2] = " ";
            tictac_board[1, 0] = " ";
            tictac_board[1, 1] = " ";
            tictac_board[1, 2] = " ";
            tictac_board[2, 0] = " ";
            tictac_board[2, 1] = " ";
            tictac_board[2, 2] = " ";
            foreach(var theView in gameGrid.Children)
            {
                int row = 0, column = 0;
                Button theButton = theView as Button; // cast View to Button
                if(theButton == ticButtonUpperLeft)
                {
                    row = 0;
                    column = 0;
                }
                if (theButton == ticButtonUpperMiddle)
                {
                    row = 0;
                    column = 1;
                }
                if (theButton == ticButtonUpperRight)
                {
                    row = 0;
                    column = 2;
                }
                if (theButton == ticButtonCenterLeft)
                {
                    row = 1;
                    column = 0;
                }
                if (theButton == ticButtonCenterMiddle)
                {
                    row = 1;
                    column = 1;
                }
                if (theButton == ticButtonCenterRight)
                {
                    row = 1;
                    column = 2;
                }
                if (theButton == ticButtonBottomLeft)
                {
                    row = 2;
                    column = 0;
                }
                if (theButton == ticButtonBottomMiddle)
                {
                    row = 2;
                    column = 1;
                }
                if (theButton == ticButtonBottomRight)
                {
                    row = 2;
                    column = 2;
                }
                SetButtonText(theButton, row, column);
            }
            ticButtonUpperLeft.Clicked += OnTicButtonUpperLeftClicked;
            ticButtonUpperMiddle.Clicked += OnTicButtonUpperMiddleClicked;
            ticButtonUpperRight.Clicked += OnTicButtonUpperRightClicked;
            
            ticButtonCenterLeft.Clicked += OnTicButtonCenterLeftClicked;
            ticButtonCenterLeft.Clicked -= OnTicButtonCenterLeftClicked;

            ticButtonCenterMiddle.Clicked += OnTicButtonCenterMiddleClicked;
            ticButtonCenterRight.Clicked += OnTicButtonCenterRightClicked;

            ticButtonBottomLeft.Clicked += OnTicButtonBottomLeftClicked;
            ticButtonBottomMiddle.Clicked += OnTicButtonBottomMiddleClicked;

            ticButtonBottomRight.Clicked += OnTicButtonBottomRightClicked;
            // ticButtonBottomRight.Clicked -= OnTicButtonBottomRightClicked;

            resetGame.Clicked += OneResetButtonClicked;

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "GameBoard Page" },
                    returnButton,
                    gameGrid,
                    playModeLabel,
                    playerModeSwitch,
                    resetGame,
                    difficultPlayLabel,
                    difficultModeSwitch
                }   
            };
            returnButton.Clicked += OneReturnButtonClicked;
            playerModeSwitch.Toggled += OnPlayerModeSwitchToggle;
            difficultModeSwitch.Toggled += OnHardPlaySwitchToggle;
        }

        void OnTicButtonBottomRightClicked(object sender, EventArgs e)
        {
            int square = 9;
            GameButtonPressedLogic(sender, square);
        }

        void OnTicButtonBottomMiddleClicked(object sender, EventArgs e)
        {
            int square = 8;
            GameButtonPressedLogic(sender, square);
        }

        void OnTicButtonBottomLeftClicked(object sender, EventArgs e)
        {
            int square = 7;
            GameButtonPressedLogic(sender, square);
        }

        void OnTicButtonCenterRightClicked(object sender, EventArgs e)
        {
            int square = 6;
            GameButtonPressedLogic(sender, square);
        }

        void OnTicButtonCenterMiddleClicked(object sender, EventArgs e)
        {
            int square = 5;
            GameButtonPressedLogic(sender, square);
        }

        void OnTicButtonCenterLeftClicked(object sender, EventArgs e)
        {
            int square = 4;
            GameButtonPressedLogic(sender, square);
        }

        void OnTicButtonUpperRightClicked(object sender, EventArgs e)
        {
            int square = 3;
            GameButtonPressedLogic(sender, square);
        }

        void OnTicButtonUpperMiddleClicked(object sender, EventArgs e)
        {
            int square = 2;
            GameButtonPressedLogic(sender, square);
        }

        void OnTicButtonUpperLeftClicked(object sender, EventArgs e)
        {
            int square = 1;
            GameButtonPressedLogic(sender, square);
        }

        void OnPlayerModeSwitchToggle(object sender, ToggledEventArgs e)
        {
            if(e.Value == true)
            {
                play_mode = ONE_PLAYER;
            } else
            {
                play_mode = TWO_PLAYERS;
            }
        }

        // Change how many players are playing

        Label playModeLabel = new Label
        {
            Text = "Press Sitch On for Single Player Mode"
        };
        Switch playerModeSwitch = new Switch
        {
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center
        };
        Label difficultPlayLabel = new Label
        {
            Text = "Press Switch On for Difficult Mode"
        };
        Switch difficultModeSwitch = new Switch
        {
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Center
        };
        Button returnButton = new Button
        {
            Text = "Return to Top"
        };
        Button ticButtonUpperLeft = new Button
        {
            Text = "UL"
        };
        Button ticButtonUpperMiddle = new Button
        {
            Text = "UM"
        };
        Button ticButtonUpperRight = new Button
        {
            Text = "UR"
        };
        Button ticButtonCenterLeft = new Button
        {
            Text = "CL"
        };
        Button ticButtonCenterMiddle = new Button
        {
            Text = "CM"
        };
        Button ticButtonCenterRight = new Button
        {
            Text = "CR"
        };
        Button ticButtonBottomLeft = new Button
        {
            Text = "BL"
        };
        Button ticButtonBottomMiddle = new Button
        {
            Text = "BM"
        };
        Button ticButtonBottomRight = new Button
        {
            Text = "BR"
        };
        Button resetGame = new Button
        {
            Text = "Reset Game"
        };
        Grid gameGrid = new Grid
        {
            RowDefinitions =
            {
                new RowDefinition { Height = GridLength.Auto},
                new RowDefinition { Height = GridLength.Auto},
                new RowDefinition { Height = GridLength.Auto}
            },
            ColumnDefinitions =
            {
                new ColumnDefinition { Width = GridLength.Auto },
                new ColumnDefinition { Width = GridLength.Auto },
                new ColumnDefinition { Width = GridLength.Auto }
            }
        };

    }
}
﻿using System;

namespace Uwarcraft.Game.StateMachine
{
    public class HelpGameState : AbstractState
    {
        public override event StateFinished StateFinishedEventHandler;

        public override void Run()
        {
            Console.WriteLine("no help menu available in pre Alpha version, press enter to return to main menu");
            Console.ReadLine();
            if (StateFinishedEventHandler != null)
            {
                StateFinishedEventHandler.Invoke(this, new StateEventArgs() { NextState = new MainMenuState() });
            }
            //game.CurentState = new MainMenu();
            //game.Do();
        }
    }
}
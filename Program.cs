using System;

namespace Door
{
    class Program
    {
        static void Main(string[] args)
        {
            Door door = new Door("Деревянная дверь");
            door.ChangeStateEvent += DoorChangeStateEvent;

            door.Open();
            door.Close();
            door.Lockup();
            door.Open();
            door.Close();
            door.Unlock();
            door.Open();

            Console.ReadKey();
        }

        private static void DoorChangeStateEvent( Door sender)
        {
            Console.WriteLine( $"{sender.Component} открыта: {sender.States.IsOpen} заперта {sender.States.IsForbidden}" );
        }
    }
}
using System;

namespace Door
{
    public class Door
    {
        public delegate void ChangeStateHandler( Door sender );

        public event ChangeStateHandler ChangeStateEvent;

        private bool _open = false;
        private bool _forbidden = false;

        public (bool IsOpen, bool IsForbidden) States
        {
            get
            {
                return (_open, _forbidden);
            }
        }

        public string Component { get; }

        public Door( string component ) => Component = component;

        public void Open()
        {
            if( _forbidden )
            {
                ChangeStateEvent( this );
                Console.WriteLine( $"{Component} не открывается!" );
                return;
            }

            _open = true;
            ChangeStateEvent( this );
            Console.WriteLine( $"{Component} открыта!" );
        }

        public void Close()
        {
            _open = false;
            ChangeStateEvent( this );
            Console.WriteLine( $"{Component} закрыта!" );
        }

        public void Lockup()
        {
            _forbidden = true;
            ChangeStateEvent( this );
            Console.WriteLine( $"{Component} заперта!" );
        }

        public void Unlock()
        {
            _forbidden = false;
            ChangeStateEvent( this );
            Console.WriteLine( $"{Component} отперта!" );
        }
    }
}

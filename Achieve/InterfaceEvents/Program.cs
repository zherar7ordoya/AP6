using System;
using static System.Console;

namespace InterfaceEvents
{
    /** **************************** INTERFACES **************************** */

    // Raise this event before drawing the object.
    public interface IDrawingObject
    {
        event EventHandler OnDraw;
    }

    // Raise this event after drawing the shape.
    public interface IShape
    {
        event EventHandler OnDraw;
    }


    /** ****************************** CLASES ****************************** */

    // Base class event publisher inherits two interfaces, each with an OnDraw event
    public class Shape : IDrawingObject, IShape
    {
        // Create an event for each interface event
        event EventHandler PreDrawEvent;
        event EventHandler PostDrawEvent;

        readonly object objectLock = new object();


        // *----------------------=> Explicit interface implementation required

        // Associate IDrawingObject's event with PreDrawEvent
        event EventHandler IDrawingObject.OnDraw
        {
            add
            {
                lock (objectLock)
                {
                    PreDrawEvent += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    PreDrawEvent -= value;
                }
            }
        }


        // Associate IShape's event with PostDrawEvent
        event EventHandler IShape.OnDraw
        {
            add
            {
                lock (objectLock)
                {
                    PostDrawEvent += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    PostDrawEvent -= value;
                }
            }


        }


        // *---------------------------------------------------------=> Métodos

        // For the sake of simplicity this one method implements both interfaces. 
        public void Draw()
        {
            EventHandler handler;

            // Raise IDrawingObject's event before the object is drawn.
            handler = PreDrawEvent;
            handler?.Invoke(this, new EventArgs());
            WriteLine("Finished 'before de object is drawn' event");

            // Raise IShape's event after the object is drawn.
            handler = PostDrawEvent;
            handler?.Invoke(this, new EventArgs());
            WriteLine("Finished 'after de object is drawn' event");
        }
    }


    /* **************************** SUBSCRIBERS **************************** */
    
    // References the shape object as an IDrawingObject
    public class Subscriber1
    {
        public Subscriber1(Shape shape)
        {
            IDrawingObject dibujo = shape;
            dibujo.OnDraw += new EventHandler(Dibujo_OnDraw);
        }

        void Dibujo_OnDraw(object sender, EventArgs e)
        {
            WriteLine("Subscriber 1 receives the IDrawingObject event.");
        }
    }


    // References the shape object as an IShape
    public class Subscriber2
    {
        public Subscriber2(Shape shape)
        {
            IShape dibujo = shape;
            dibujo.OnDraw += new EventHandler(Dibujo_OnDraw);
        }

        void Dibujo_OnDraw(object sender, EventArgs e)
        {
            WriteLine("Subscriber 2 receives the IShape event.");
        }
    }


    /* ****************************** PROGRAM ****************************** */

    public class Program
    {
        static void Main(string[] args)
        {
            Shape shape = new Shape();
            _ = new Subscriber1(shape);
            _ = new Subscriber2(shape);
            shape.Draw();

            // Keep the console window open in debug mode.
            WriteLine("Press any key to exit...");
            ReadKey();
        }
    }
}
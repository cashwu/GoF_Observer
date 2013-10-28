using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
        }
    }

    public interface ISubject
    {
        void addObserver(IObserver obj);

        void deleteObserver(IObserver obj);

        void notifyObserver();
    }

    public interface IObserver
    {
        void update(ISubject obj);
    }

    public enum State
    {
        OK,
        CRITICAL
    }

    public class MonitoredItem : ISubject
    {
        private List<IObserver> _observer = new List<IObserver>();

        private State _state = State.OK;

        public void addObserver(IObserver obj)
        {
            _observer.Add(obj);
        }

        public void deleteObserver(IObserver obj)
        {
            _observer.Remove(obj);
        }

        public void notifyObserver()
        {
            foreach (IObserver obj in _observer)
            {
                obj.update(this);
            }
        }

        public void changeState(State aNewState)
        {
            _state = aNewState;

            this.notifyObserver();
        }

        public State getState()
        {
            return _state;
        }
    }

    public class ChangeLogger : IObserver
    {
        public void update(ISubject obj)
        {
            writeChangeLog(((MonitoredItem)obj).getState(), DateTime.Now);
        }

        private void writeChangeLog(State state, DateTime date)
        {
        }
    }

    public class MockChangeLogger : IObserver
    {
        public int _notifiedCount = 0;

        public void update(ISubject obj)
        {
            _notifiedCount++;
        }
    }
}
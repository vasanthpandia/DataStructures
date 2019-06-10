using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Event
    {
        enum Type
        {
            Dinner, Conference, Seminar, Auction, Workshop
        }

        string title;
        Type eventType;
        float seatPrice;
        int seats;
        DateTime eventDate;

        public Event(string title, int type, int max_seats, float seat_price)
        {
            this.title = title;
            eventType = (Type) type;
            seats = max_seats;
            seatPrice = seat_price;

        }

        public void DisplayEvent()
        {

        }
    }
}

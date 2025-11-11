using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssesmentBackendDeveloper_FarukAbdullah
{
    public class Booking
    {
        public string GuestName { get; private set; }
        public string RoomNumber { get; private set; }
        public DateTime CheckInDate { get; private set; }
        public DateTime CheckOutDate { get; private set; }
        public int TotalDays => (CheckOutDate - CheckInDate).Days;
        public double RatePerDay { get; private set; }
        public double DiscountPercent { get; private set; }
        public double TotalAmount { get; private set; }
        public bool IsCancelled { get; private set; }

        public Booking(string guestName, string roomNumber, DateTime checkIn, DateTime checkOut, double ratePerDay, double discountPercent = 0)
        {
            if (string.IsNullOrWhiteSpace(guestName))
                throw new ArgumentException("Guest name cannot be empty.");
            if (checkOut <= checkIn)
                throw new ArgumentException("Checkout date must be after check-in date.");
            if (ratePerDay <= 0)
                throw new ArgumentException("Rate per day must be positive.");

            GuestName = guestName;
            RoomNumber = roomNumber;
            CheckInDate = checkIn;
            CheckOutDate = checkOut;
            RatePerDay = ratePerDay;
            DiscountPercent = discountPercent;
        }

        public void CalculateTotal()
        {
            var gross = TotalDays * RatePerDay;
            var discount = gross * (DiscountPercent / 100);
            TotalAmount = gross - discount;
        }

        public async Task LogBookingDetailsAsync()
        {
            // Simulate async logging (to file, database, or API)
            await Task.Delay(500);
            Console.WriteLine("✅ Booking details logged successfully.");
        }

        public void Cancel()
        {
            IsCancelled = true;
            Console.WriteLine($"❌ Booking for {GuestName} has been cancelled.");
        }

        public void PrintSummary()
        {
            Console.WriteLine("\n=== Booking Summary ===");
            Console.WriteLine($"Guest: {GuestName}");
            Console.WriteLine($"Room: {RoomNumber}");
            Console.WriteLine($"Check-in: {CheckInDate:yyyy-MM-dd}");
            Console.WriteLine($"Check-out: {CheckOutDate:yyyy-MM-dd}");
            Console.WriteLine($"Days: {TotalDays}");
            Console.WriteLine($"Rate/Day: {RatePerDay:C}");
            Console.WriteLine($"Discount: {DiscountPercent}%");
            Console.WriteLine($"Total Amount: {TotalAmount:C}");
            Console.WriteLine("=========================");
        }
    }

    public static class AppHost
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var booking = new Booking(
                    guestName: "Alice",
                    roomNumber: "101",
                    checkIn: DateTime.Now,
                    checkOut: DateTime.Now.AddDays(3),
                    ratePerDay: 150.5,
                    discountPercent: 10
                );

                booking.CalculateTotal();
                booking.PrintSummary();
                await booking.LogBookingDetailsAsync();

                booking.Cancel();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❗ Error: {ex.Message}");
            }
        }
    }
}

// <copyright file="DatabaseService.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Services
{
    using SQLite;
    using VocalLink_L00152171.Model;

    /// <summary>
    /// SQLite Databse service.
    /// </summary>
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection conn;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseService"/> class.
        /// </summary>
        /// <param name="dbPath"> The path for the Databse. </param>
        public DatabaseService(string dbPath)
        {
            this.conn = new SQLiteAsyncConnection(dbPath);
            this.conn.CreateTableAsync<User>().Wait();
            this.conn.CreateTableAsync<Booking>().Wait();
            this.conn.CreateTableAsync<Singer>().Wait();
        }

        ///////// User Methods /////////////

        /// <summary>
        /// Retrieves all users from the database asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<List<User>> GetUserAsync()
        {
            return this.conn.Table<User>().ToListAsync();
        }

        /// <summary>
        /// Saves a user to the database asynchronously.
        /// </summary>
        /// <param name="user"> User info passed in to be saved to Database.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<int> SaveUserAsync(User user)
        {
            return this.conn.InsertAsync(user);
        }

        /// <summary>
        /// Delete all users from the database asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<int> DeleteAllUsersAsync()
        {
            return this.conn.ExecuteAsync("DELETE FROM User");
        }

        ///////// Booking Methods /////////////

        /// <summary>
        /// Get all bookings for a specific singer asynchronously.
        /// </summary>
        /// <param name="email"> Singers email for retrieving bookings.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<List<Booking>> GetSingerBookingsAsync(string email)
        {
            return this.conn.Table<Booking>().Where(b => b.SingerEmail == email).ToListAsync();
        }

        /// <summary>
        /// Get all bookings for a specific business asynchronously.
        /// </summary>
        /// <param name="email"> Business email for retrieving bookings.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<List<Booking>> GetBusinessBookingsAsync(string email)
        {
            return this.conn.Table<Booking>().Where(b => b.BusinessEmail == email).ToListAsync();
        }

        /// <summary>
        /// Check if booking already exists Save if unique update status if already exists.
        /// </summary>
        /// <param name="booking"> Booking Value to be saved. </param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<int> SaveBookingAsync(Booking booking)
        {
            if (booking.Id != 0)
            {
                return this.conn.UpdateAsync(booking);
            }
            else
            {
                return this.conn.InsertAsync(booking);
            }
        }

        /// <summary>
        /// Delete a booking from the database asynchronously.
        /// </summary>
        /// <param name="booking"> Booking details to be deleted. </param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<int> DeleteBookingAsync(Booking booking)
        {
            return this.conn.DeleteAsync(booking);
        }

        ///////// Singer Methods /////////////

        /// <summary>
        /// Get all singers from the database asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<List<Singer>> GetAllSingersAsync()
        {
            return this.conn.Table<Singer>().ToListAsync();
        }

        /// <summary>
        /// Save or update singer in the database asynchronously.
        /// </summary>
        /// <param name="singer"> Singer to be saved or updated. </param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<int> SaveSingerProfileAsync(Singer singer)
        {
            return this.conn.InsertOrReplaceAsync(singer);
        }

        /// <summary>
        /// Get a singer's profile by email asynchronously.
        /// </summary>
        /// <param name="email"> Email used to retrive the singer. </param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        public Task<Singer> GetSingerProfileAsync(string email)
        {
            return this.conn.Table<Singer>().Where(s => s.UserEmail == email).FirstOrDefaultAsync();
        }
    }
}
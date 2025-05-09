using SQLite;
using VocalLink_L00152171.Model;

namespace VocalLink_L00152171.Services;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection conn;
    public DatabaseService(string dbPath)
    {
        conn = new SQLiteAsyncConnection(dbPath);
        conn.CreateTableAsync<User>().Wait();
        conn.CreateTableAsync<Booking>().Wait();
        conn.CreateTableAsync<Singer>().Wait();
    }

    //user methods ////
    ///////////////////
    public Task<List<User>> GetUserAsync()
    {
        return conn.Table<User>().ToListAsync();
    }

    public Task<int> SaveUserAsync(User user)
    {
        return conn.InsertAsync(user);
    }
    public Task<int> DeleteAllUsersAsync()
    {
        return conn.ExecuteAsync("DELETE FROM User");
    }

    //Booking methods ////
    ///////////////////
    public Task<List<Booking>> GetSingerBookingsAsync(string email)
    {
        return conn.Table<Booking>().Where(b => b.SingerEmail == email).ToListAsync();
    }
    public Task<List<Booking>> GetBusinessBookingsAsync(string email)
    {
        return conn.Table<Booking>().Where(b => b.BusinessEmail == email).ToListAsync();
    }

    public Task<int> SaveBookingAsync(Booking booking)
    {
        return conn.InsertAsync(booking);
    }

    public Task<int> DeleteBookingAsync(Booking booking)
    {
        return conn.DeleteAsync(booking);
    }

    //Singer methods ////
    ///////////////////
    public Task<List<Singer>> GetAllSingersAsync()
    {
        return conn.Table<Singer>().ToListAsync();
    }
    public Task<int> SaveSingerProfileAsync(Singer singer)
    {
        return conn.InsertOrReplaceAsync(singer);
    }
    public Task<Singer> GetSingerProfileAsync(string email)
    {
        return conn.Table<Singer>().Where(s => s.UserEmail == email).FirstOrDefaultAsync();
    }

}
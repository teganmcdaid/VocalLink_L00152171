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
}
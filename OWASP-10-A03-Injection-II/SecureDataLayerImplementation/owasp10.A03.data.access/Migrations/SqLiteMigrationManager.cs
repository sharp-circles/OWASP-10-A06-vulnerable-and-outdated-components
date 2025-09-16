using owasp10.A03.business.Entities;
using SQLite;
using System.Reflection;

namespace owasp10.A03.data.access.Migrations;

public static class SqLiteMigrationManager
{
    private static readonly string DbName = SqLiteConstants.DbName;
    private static readonly string DbDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "./";

    public static async Task RunMigrationsAsync()
    {
        var context = new SQLiteAsyncConnection(Path.Combine(DbDirectory, DbName));

        var medicalHistories = await context.GetTableInfoAsync(nameof(MedicalHistory));

        if (!medicalHistories.Any())
        {
            await context.CreateTableAsync<Tables.MedicalHistory>();

            var medicalHistoryUserOne = new Tables.MedicalHistory()
            {
                Id = 1,
                UserId = 1,
                UserName = "Matthew",
                Age = 42,
                Affection = "Fibromyalgia",
                Treatment = "Advil",
                UndergoneSurgery = true
            };

            var medicalHistoryUserTwo = new Tables.MedicalHistory()
            {
                Id = 2,
                UserId = 2,
                UserName = "McConaughey",
                Age = 38,
                Affection = "Arrhythmia",
                Treatment = "Marlboro Cigarettes",
                UndergoneSurgery = true
            };

            await context.InsertAsync(medicalHistoryUserOne);
            await context.InsertAsync(medicalHistoryUserTwo);
        }

        await context.CloseAsync();
    }
}

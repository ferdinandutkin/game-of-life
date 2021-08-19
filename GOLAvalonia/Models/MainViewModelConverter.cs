using ReactiveCore.Models;
using ReactiveCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GOLAvalonia.ViewModels
{
    class MainViewModelConverter : JsonConverter<MainWindowViewModel>
    {

        private static string propertyName = "Game";
        public override MainWindowViewModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {


            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            reader.Read();

           

            var convertedName = options.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName;


            if (reader.TokenType != JsonTokenType.PropertyName && reader.GetString() != convertedName)
                throw new JsonException();

            var table = JsonSerializer.Deserialize<bool[][]>(ref reader, options);


            if (reader.TokenType != JsonTokenType.EndArray)
                throw new JsonException();


            reader.Read();


            if (reader.TokenType != JsonTokenType.EndObject)
                throw new JsonException();


            reader.Read();



            var (height, width) = (table.Length, table[0].Length);

            var reactiveTable = new ReactiveTile[height, width];


            for (int i = 0; i < height; i++)
            {

                for (int j = 0; j < width; j++)
                {

                    reactiveTable[i, j] = new ReactiveTile() { IsAlive = table[i][j] };

                }
            }

            GameViewModel game = new(new ReactiveGame(new ReactiveField(reactiveTable)));

            return new MainWindowViewModel()
            {
                Game = game
            };
        }

        public override void Write(Utf8JsonWriter writer, MainWindowViewModel value, JsonSerializerOptions options)
        {
            var reactiveTable = value.Game.Model.Field.Table;

            var (height, width) = (reactiveTable.GetLength(0), reactiveTable.GetLength(1));

            bool[][] table = new bool[height][];


            for (int i = 0; i < height; i++)
            {
                table[i] = new bool[width];

                for (int j = 0; j < width; j++)
                {

                    table[i][j] = reactiveTable[i,j].IsAlive;

                }
            }




            writer.WriteStartObject();



            var convertedName = options.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName;

            writer.WritePropertyName(convertedName);

            JsonSerializer.Serialize(writer, table, options);

            writer.WriteEndObject();
            
           
        }
    }
}

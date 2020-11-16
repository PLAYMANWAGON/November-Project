using System;
using Raylib_cs;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "Zelli's Quest");

            Random generator = new Random();



            string scene = "titleScreen";

            string[] menuSelect = { "start", "options" };

            float xPos = 384;

            float yPos = 284;

            int menu = 0;

            string[] prologue = { "Dialogue 1", "Dialogue 2" };

            //Minion Texture

            Image minionImg = Raylib.LoadImage(@"minion.png");

            Raylib.ImageResize(ref minionImg, 32, 32);

            Texture2D minionTex = Raylib.LoadTextureFromImage(minionImg);

            //Grass Texture

            Image grassImg = Raylib.LoadImage(@"grassTex.png");

            Raylib.ImageResizeNN(ref grassImg, 64, 64);

            Texture2D grassTex = Raylib.LoadTextureFromImage(grassImg);








            while (!Raylib.WindowShouldClose())
            {

                Raylib.SetWindowIcon(grassImg);




                if (scene == "game")
                {

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                    {

                        xPos += 0.5f;

                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {

                        xPos -= 0.5f;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                    {

                        yPos -= 0.5f;
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                    {

                        yPos += 0.5f;
                    }


                    Raylib.BeginDrawing();

                    Raylib.ClearBackground(Color.WHITE);

                    //Raylib.DrawTexture(minionTex, (int)xPos, (int)yPos, Color.WHITE);

                    Raylib.EndDrawing();




                }

                if (scene == "titleScreen")
                {

                    Raylib.BeginDrawing();

                    Raylib.ClearBackground(Color.PURPLE);

                    Raylib.DrawText("Text", 240, 100, 128, Color.WHITE);

                    Raylib.DrawText("Start Game", 300, 300, 32, Color.WHITE);
                    Raylib.DrawText("Options", 330, 350, 32, Color.WHITE);



                    foreach (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN) && menu < 2)
                    {

                        menu++;

                    }




                    Raylib.EndDrawing();
                }





            }


        }
    }
}

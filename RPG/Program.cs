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

            string facing = "south";

            string[] menuSelect = { "start", "options" };

            float xPos = 384;

            float yPos = 284;

            int menu = 0;

            int width = 800;

            //int height = 600;

            string[] prologue = { "Dialogue 1", "Dialogue 2" };

            //Character Texture Inside

            Image charImg = Raylib.LoadImage(@"still.png");

            Texture2D stand = Raylib.LoadTextureFromImage(charImg);



            //Character Texture - World




            Image charLoN = Raylib.LoadImage(@"worldN.png");

            Texture2D worldN = Raylib.LoadTextureFromImage(charLoN);


            Image charLoS = Raylib.LoadImage(@"worldS.png");

            Texture2D worldS = Raylib.LoadTextureFromImage(charLoS);


            Image charLoE = Raylib.LoadImage(@"worldE.png");

            Texture2D worldE = Raylib.LoadTextureFromImage(charLoE);

  
            Image charLoW = Raylib.LoadImage(@"worldW.png");

            Texture2D worldW = Raylib.LoadTextureFromImage(charLoW);




            //Grass Texture

            Image grassImg = Raylib.LoadImage(@"grassTex.png");

            Raylib.ImageResizeNN(ref grassImg, 64, 64);

            Texture2D grassTex = Raylib.LoadTextureFromImage(grassImg);

            Raylib.SetTargetFPS(60);








            while (!Raylib.WindowShouldClose())
            {


                if (scene == "game")
                {

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                    {
                        facing = "east";

                        Raylib.DrawTexture(worldE, (int)xPos, (int)yPos, Color.WHITE);

                        xPos += 5f;

                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                        facing = "west";

                        Raylib.DrawTexture(worldW, (int)xPos, (int)yPos, Color.WHITE);

                        xPos -= 5f;

                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                    {
                        facing = "north";

                        Raylib.DrawTexture(worldN, (int)xPos, (int)yPos, Color.WHITE);

                        yPos -= 5f;
                        
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                    {
                        facing = "south";

                        Raylib.DrawTexture(worldS, (int)xPos, (int)yPos, Color.WHITE);

                        yPos += 5f;
                    }


                    //"KEEP CHARACTER SPRITE IN THE SAME DIRECTION WHEN NOT PRESSING ANYTHING" CODE


                    if (facing == "east") {

                        Raylib.DrawTexture(worldE, (int)xPos, (int)yPos, Color.WHITE);

                    }

                    if (facing == "west") {

                        Raylib.DrawTexture(worldW, (int)xPos, (int)yPos, Color.WHITE);

                    }

                    if (facing == "north") {

                        Raylib.DrawTexture(worldN, (int)xPos, (int)yPos, Color.WHITE);

                    }

                    if (facing == "south"){

                        Raylib.DrawTexture(worldS, (int)xPos, (int)yPos, Color.WHITE);

                    }


                    Raylib.BeginDrawing();

                    Raylib.ClearBackground(Color.WHITE);

                    Raylib.EndDrawing();




                }

                if (scene == "titleScreen")
                {
                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN)){

                        menu ++;

                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP)){

                        menu --;

                    }


                    Raylib.BeginDrawing();

                    
                        if (menu == 0) {

                            Raylib.DrawText("<", 500, 300, 32, Color.WHITE);

                        }

                        if (menu == 1) {

                            Raylib.DrawText("<", 500, 350, 32, Color.WHITE);

                        }

                        if (menu == 2) {

                            Raylib.DrawText("<", 500, 400, 32, Color.WHITE);

                        }

                        if (menu == 0 && Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER)) {

                            scene = "game";
                        }


                    Raylib.ClearBackground(Color.PURPLE);

                    Raylib.DrawText("Text", 240, 100, 128, Color.WHITE);

                    Raylib.DrawText("Start Game", width/3 + 20, 300, 32, Color.WHITE);
                    Raylib.DrawText("Options", width/3 + 20, 350, 32, Color.WHITE);
                    Raylib.DrawText("Quit", width/3 + 20, 400, 32, Color.WHITE);
                    




                    Raylib.EndDrawing();
                }





            }


        }
    }
}

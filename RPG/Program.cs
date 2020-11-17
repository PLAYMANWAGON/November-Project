using System;
using Raylib_cs;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "Zelli's Quest");

            //THE COOL GENERATOR

            Random generator = new Random();

            //CollisionDetection Square

            new colRect = 

            //-----STRINGS-----

            //GAME SCENE THINGY

            string scene = "titleScreen";

            //THE STRING THAT MAKES THE CHARACTER FACE THE SAME DIRECTION AFTER RELEASING A DIRECTION BUTTON

            string facing = "south";

            //TALKY STUFF

            string[] text = { "Dialogue 1", "Dialogue 2" };

            //-----FLOATS-----

            //CHARACTER STARTING POSITION

            float xPos = 384;

            float yPos = 284;

            //-----INTEGERS-----

            //THE SHITTY INTEGER THAT MAKES THE MENU WORK (IF IT WORKS, IT WORKS)

            int menu = 0;

            //WIDTH AND HEIGHT INTEGERS IF I NEED TO PLACE SOMETHING IN SOME POSITION

            int width = 800;

            int height = 600;


            //-----IMAGES AND TEXTURES AND SCENES-----


            //CHARACTER TEXTURE - INSIDE

            Image charImg = Raylib.LoadImage(@"still.png");

            Texture2D stand = Raylib.LoadTextureFromImage(charImg);



            //CHARACTER TEXTURE - WORLD



                    //NORTH--------------------------------------------------
            Image charLoN = Raylib.LoadImage(@"worldN.png");

            Raylib.ImageResizeNN(ref charLoN, 64, 64);

            Texture2D worldN = Raylib.LoadTextureFromImage(charLoN);

                    //SOUTH--------------------------------------------------
            Image charLoS = Raylib.LoadImage(@"worldS.png");

            Raylib.ImageResizeNN(ref charLoS, 64, 64);

            Texture2D worldS = Raylib.LoadTextureFromImage(charLoS);

                    //EAST--------------------------------------------------
            Image charLoE = Raylib.LoadImage(@"worldE.png");

            Raylib.ImageResizeNN(ref charLoE, 64, 64);

            Texture2D worldE = Raylib.LoadTextureFromImage(charLoE);

                    //WEST--------------------------------------------------
            Image charLoW = Raylib.LoadImage(@"worldW.png");

            Raylib.ImageResizeNN(ref charLoW, 64, 64);

            Texture2D worldW = Raylib.LoadTextureFromImage(charLoW);




            //CRAP GRASS TEXTURE

            Image grassImg = Raylib.LoadImage(@"grassTex.png");

            Raylib.ImageResizeNN(ref grassImg, 64, 64);

            Texture2D grassTex = Raylib.LoadTextureFromImage(grassImg);

            //SCENE 1 TEXTURES

                //SCENERY

            Image scene1Img = Raylib.LoadImage(@"scene1.png");

            Raylib.ImageResizeNN(ref scene1Img, 800, 600);

            Texture2D scene1Tex = Raylib.LoadTextureFromImage(scene1Img);

                //SCENERY OBJECTS
            
            //TOP LAYER
            Image scene1ObjLyr1Img = Raylib.LoadImage(@"scene1ObjLyr1.png");

            Raylib.ImageResizeNN(ref scene1ObjLyr1Img, 800, 600);

            Texture2D scene1ObjLyr1Tex = Raylib.LoadTextureFromImage(scene1ObjLyr1Img);

            //BOTTOM LAYER
            Image scene1ObjLyr2Img = Raylib.LoadImage(@"scene1ObjLyr2.png");

            Raylib.ImageResizeNN(ref scene1ObjLyr2Img, 800, 600);

            Texture2D scene1ObjLyr2Tex = Raylib.LoadTextureFromImage(scene1ObjLyr2Img);







            Raylib.SetTargetFPS(60);








            while (!Raylib.WindowShouldClose())
            {


                if (scene == "game")
                {

                    //SCENE AND BOTTOM TEXTURES

                    Raylib.DrawTexture(scene1Tex, 0, 0, Color.WHITE);

                    Raylib.DrawTexture(scene1ObjLyr2Tex, 0, 0, Color.WHITE);



                    //IMPORTANT BOOLEAN

                    bool isMoving = false;


                    Raylib.DrawRectangle(600, 200, 100, 100, Color.WHITE);


                    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                    {
                        facing = "east";

                        Raylib.DrawTexture(worldE, (int)xPos, (int)yPos, Color.WHITE);

                        xPos += 5f;

                        isMoving = true;

                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                        facing = "west";

                        Raylib.DrawTexture(worldW, (int)xPos, (int)yPos, Color.WHITE);

                        xPos -= 5f;

                        isMoving = true;

                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                    {
                        facing = "north";

                        Raylib.DrawTexture(worldN, (int)xPos, (int)yPos, Color.WHITE);

                        yPos -= 5f;

                        isMoving = true;
                        
                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                    {
                        facing = "south";

                        Raylib.DrawTexture(worldS, (int)xPos, (int)yPos, Color.WHITE);

                        yPos += 5f;

                        isMoving = true;
                    }

                    //THE CODE THAT REMOVES GHOSTING (OTHERWISE TWO SPRITES ARE DISPLAYED AT THE SAME TIME WHILE MOVING)

                    if (isMoving == false) {
                    
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

                    }

                
                //THE OTHER TEXTURE THAT MAKES CHARACTER STAY BEHIND OBJECTS
                Raylib.DrawTexture(scene1ObjLyr1Tex, 0 , 0 , Color.WHITE);


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

                        if (menu > 2) {

                             menu = 2;
                        }

                        if (menu < 0) {

                            menu = 0;
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

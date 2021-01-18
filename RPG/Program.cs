using System.Runtime.ConstrainedExecution;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Collections;
using System.ComponentModel;
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

            #region strings

            //GAME SCENE

            string scene = "titleScreen";

            //THE STRING THAT MAKES THE CHARACTER FACE THE SAME DIRECTION AFTER RELEASING A DIRECTION BUTTON

            string facing = "south";

            //TALKY STUFF

            string[] text = { "Dialogue 1", "Dialogue 2" };

            #endregion

            #region floats

            //CHARACTER STARTING POSITION

            float xPos = 384;

            float yPos = 284;

            //AUDIO SETTINGS

            float musicVolume = 1f;

            float afxVolume = 1f;
            
            string muVolString = musicVolume.ToString();

            string afxVolString = afxVolume.ToString();

            #endregion

            #region integers

            //THE SHITTY INTEGER THAT MAKES THE MENU WORK (IF IT WORKS, IT WORKS)

            int menu = 0;

            int optionMenu = 0;

            int battleMenu = 0;

            //WIDTH AND HEIGHT INTEGERS IF I NEED TO PLACE SOMETHING IN SOME POSITION

            int width = 800;


            //HEALTH FOR BATTLE

            int pHealth = 100;

            int eHealth = 100;

            #endregion

            //COLLISION SQUARE

            Rectangle colRect = new Rectangle(590, 200, 100, 100);

            Rectangle colRect2 = new Rectangle(200, 250, 50, 50);

            #region Textures

            //-----IMAGES AND TEXTURES AND SCENES-----

            #region Character Textures

            //NORTH----------------------------------------------------------

            Image charLoN = Raylib.LoadImage(@"worldN.png");

            Raylib.ImageResizeNN(ref charLoN, 64, 64);

            Texture2D worldN = Raylib.LoadTextureFromImage(charLoN);


            //SOUTH-----------------------------------------------------------

            Image charLoS = Raylib.LoadImage(@"worldS.png");

            Raylib.ImageResizeNN(ref charLoS, 64, 64);

            Texture2D worldS = Raylib.LoadTextureFromImage(charLoS);

            //EAST------------------------------------------------------------

            Image charLoE = Raylib.LoadImage(@"worldE.png");

            Raylib.ImageResizeNN(ref charLoE, 64, 64);

            Texture2D worldE = Raylib.LoadTextureFromImage(charLoE);

            //WEST------------------------------------------------------------

            Image charLoW = Raylib.LoadImage(@"worldW.png");

            Raylib.ImageResizeNN(ref charLoW, 64, 64);

            Texture2D worldW = Raylib.LoadTextureFromImage(charLoW);



            #endregion

            #region Scene Textures

            #region scene 1

            //SCENERY-1----------------------------------------------------------------------

            Image scene1Img = Raylib.LoadImage(@"scene1.png");

            Raylib.ImageResizeNN(ref scene1Img, 800, 600);

            Texture2D scene1Tex = Raylib.LoadTextureFromImage(scene1Img);


            //SCENERY 1 OBJECTS

            //TOP LAYER----------------------------------------------------------------------

            Image scene1ObjLyr1Img = Raylib.LoadImage(@"scene1ObjLyr1.png");

            Raylib.ImageResizeNN(ref scene1ObjLyr1Img, 800, 600);

            Texture2D scene1ObjLyr1Tex = Raylib.LoadTextureFromImage(scene1ObjLyr1Img);

            //BOTTOM LAYER--------------------------------------------------------------------

            Image scene1ObjLyr2Img = Raylib.LoadImage(@"scene1ObjLyr2.png");

            Raylib.ImageResizeNN(ref scene1ObjLyr2Img, 800, 600);

            Texture2D scene1ObjLyr2Tex = Raylib.LoadTextureFromImage(scene1ObjLyr2Img);
            //--------------------------------------------------------------------------------

            #endregion

            #region fight scene

            Image battleImg = Raylib.LoadImage(@"battlesketch.png");

            Texture2D battleTex = Raylib.LoadTextureFromImage(battleImg);

            Image winImg = Raylib.LoadImage(@"winning.jpg");

            Texture2D winTex = Raylib.LoadTextureFromImage(winImg);


            #endregion


            #endregion

            #endregion

            #region Audio
            
            Raylib.InitAudioDevice();

            Music menuMusic = Raylib.LoadMusicStream(@"MenuMusic.mp3");

            Raylib.PlayMusicStream(menuMusic);

            Sound menuEnter = Raylib.LoadSound(@"MenuEnter.wav");

            Sound menuExit = Raylib.LoadSound(@"MenuExit.wav");

            Sound menuSelect = Raylib.LoadSound(@"MenuSelect.wav");

            //GAME AUDIO------------------------------------------------------

            Music gameMusic = Raylib.LoadMusicStream(@"GameMusic.mp3");

            Raylib.PlayMusicStream(gameMusic);

            //BATTLE AUDIO----------------------------------------------------

            Music battleMusic = Raylib.LoadMusicStream(@"fight.mp3");

            Raylib.PlayMusicStream(battleMusic);

            #endregion

            Raylib.SetTargetFPS(60);


            while (!Raylib.WindowShouldClose())
            {

                //PLAYERBOX FOR COLLISIONS N SHIT

                Rectangle playRect = new Rectangle(xPos + 10, yPos + 52, 44, 12);

                bool areOverlapping = Raylib.CheckCollisionRecs(colRect, playRect);

                bool areOverlapping2 = Raylib.CheckCollisionRecs(colRect2, playRect);


                if (scene == "game")
                {

                    Raylib.UpdateMusicStream(gameMusic);

                    Raylib.PlayMusicStream(gameMusic);

                    //SCENE AND BOTTOM TEXTURES

                    Raylib.DrawTexture(scene1Tex, 0, 0, Color.WHITE);

                    Raylib.DrawTexture(scene1ObjLyr2Tex, 0, 0, Color.WHITE);



                    //IMPORTANT BOOLEAN

                    bool isMoving = false;


                    #region CollisionBoxes

                    Raylib.DrawRectangleRec(colRect, Color.BLANK);

                    Raylib.DrawRectangleRec(playRect, Color.BLANK);

                    Raylib.DrawRectangleRec(colRect2, Color.BLANK);

                    #endregion


                    //MOVEMENT, DIRECTION, SCARY MONSTERS AND NICE SPRITES AND CRAP 

                    float xMovement = 0;
                    float yMovement = 0;
                    
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                    {
                        facing = "east";

                        Raylib.DrawTexture(worldE, (int)xPos, (int)yPos, Color.WHITE);

                        xMovement = 5f;

                        isMoving = true;

                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                        facing = "west";

                        Raylib.DrawTexture(worldW, (int)xPos, (int)yPos, Color.WHITE);

                        xMovement = -5f;

                        isMoving = true;

                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                    {
                        facing = "north";

                        Raylib.DrawTexture(worldN, (int)xPos, (int)yPos, Color.WHITE);

                        yMovement = -5f;

                        isMoving = true;

                    }

                    if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                    {
                        facing = "south";

                        Raylib.DrawTexture(worldS, (int)xPos, (int)yPos, Color.WHITE);

                        yMovement = 5f;

                        isMoving = true;
                    }

                    xPos += xMovement;
                    yPos += yMovement;


                    if (Raylib.CheckCollisionRecs(playRect, colRect))
                    {
                        xPos -= xMovement;
                    }

                    if (Raylib.CheckCollisionRecs(playRect, colRect2))
                    {
                        xPos += xMovement;
                    }



                    //THE CODE THAT REMOVES GHOSTING (OTHERWISE TWO SPRITES ARE DISPLAYED AT THE SAME TIME WHILE MOVING)

                    if (isMoving == false)
                    {

                        if (facing == "east")
                        {

                            Raylib.DrawTexture(worldE, (int)xPos, (int)yPos, Color.WHITE);

                        }

                        if (facing == "west")
                        {

                            Raylib.DrawTexture(worldW, (int)xPos, (int)yPos, Color.WHITE);

                        }

                        if (facing == "north")
                        {

                            Raylib.DrawTexture(worldN, (int)xPos, (int)yPos, Color.WHITE);

                        }

                        if (facing == "south")
                        {

                            Raylib.DrawTexture(worldS, (int)xPos, (int)yPos, Color.WHITE);

                        }

                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_B)) 
                    {

                        scene = "battle";

                        
                    }

                    //THE OTHER TEXTURE THAT MAKES CHARACTER STAY BEHIND OBJECTS
                    Raylib.DrawTexture(scene1ObjLyr1Tex, 0, 0, Color.WHITE);


                    Raylib.BeginDrawing();

                    Raylib.ClearBackground(Color.WHITE);

                    Raylib.EndDrawing();


                }

                if (scene == "battle")
                {
                    Raylib.UpdateMusicStream(battleMusic);

                    Raylib.PlayMusicStream(battleMusic);

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN))
                    {

                        Raylib.PlaySound(menuSelect);

                        battleMenu++;

                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
                    {

                        Raylib.PlaySound(menuSelect);

                        battleMenu--;

                    }

                    if (battleMenu > 1)
                    {

                        battleMenu = 1;
                    }

                    if (battleMenu < 0)
                    {

                        battleMenu = 0;
                    }

                    if (battleMenu == 0 && Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        int dmg = generator.Next(51);

                        eHealth = eHealth - DamageMaker.StrikeDamage(dmg);

                            
                    }

                    if (battleMenu == 1 && Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        int dmg = generator.Next(10, 61);

                        eHealth = eHealth - DamageMaker.MagicDamage(dmg);
                    }

                    if (eHealth <= 0)
                    {

                    scene = "win";

                    }

                    Raylib.BeginDrawing();

                    Raylib.DrawText("Strike", 50, 450, 26, Color.BLACK);
                    Raylib.DrawText("Magic", 50, 500, 26, Color.BLACK);
                    Raylib.DrawText("Enemy Health: " + eHealth + " /100", 350, 100, 36, Color.BLACK);


                    if (battleMenu == 0)
                    {
                        Raylib.DrawText("<", 150, 450, 32, Color.BLACK);
                    }

                    if (battleMenu == 1)
                    {
                        Raylib.DrawText("<", 150, 500, 32, Color.BLACK);
                    }



                    Raylib.ClearBackground(Color.WHITE);

                    Raylib.EndDrawing();

                }

                if (scene == "win")
                {
                    Raylib.BeginDrawing();

                    Raylib.DrawText("Texturer har slutat fungera så \n det här får vara min win \n screen :/", 20, 20, 36, Color.MAGENTA);

                    Raylib.ClearBackground(Color.WHITE);

                    Raylib.EndDrawing();
                }

                if (scene == "options")
                {

                    Raylib.UpdateMusicStream(menuMusic);


                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN))
                    {

                        Raylib.PlaySound(menuSelect);

                        optionMenu++;

                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
                    {

                        Raylib.PlaySound(menuSelect);

                        optionMenu--;

                    }


                    Raylib.BeginDrawing();

                    if (optionMenu == 0)
                    {

                        Raylib.DrawText("<", 600, 300, 32, Color.WHITE);

                    }

                    if (optionMenu == 1)
                    {

                        Raylib.DrawText("<", 600, 350, 32, Color.WHITE);

                    }

                    if (optionMenu == 2)
                    {

                        Raylib.DrawText("<", 500, 400, 32, Color.WHITE);

                    }

                    if (optionMenu == 0 && Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT))
                    {

                        musicVolume = musicVolume -= 0.1f;

                        
                    }

                    if (optionMenu == 1 && Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT))
                    {

                        afxVolume = afxVolume - 0.1f;

                        
                    }

                    if (optionMenu == 2 && Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {

                        Raylib.PlaySound(menuExit);

                        scene = "titleScreen";
                    }

                    if (optionMenu > 2)
                    {

                        optionMenu = 2;
                    }

                    if (optionMenu < 0)
                    {

                        optionMenu = 0;
                    }

                    

                    Raylib.ClearBackground(Color.BLUE);

                    Raylib.DrawText("Options", 200, 100, 128, Color.WHITE);

                    Raylib.DrawText("Music Volume", width / 4 , 300, 32, Color.WHITE);
                    Raylib.DrawText(muVolString, 500, 300 , 32, Color.MAGENTA);

                    Raylib.DrawText("AFX Volume", width / 4, 350, 32, Color.WHITE);
                    Raylib.DrawText(afxVolString, 500, 350 , 32, Color.MAGENTA);


                    Raylib.DrawText("Back", width / 2 - 40, 400, 32, Color.WHITE);

                    


                    Raylib.EndDrawing();
                }

                if (scene == "titleScreen")
                {
                    Raylib.SetMusicVolume(menuMusic, musicVolume);

                    Raylib.UpdateMusicStream(menuMusic);

                    Raylib.PlayMusicStream(menuMusic);

                    Raylib.SetSoundVolume(menuEnter, afxVolume);
                    Raylib.SetSoundVolume(menuExit, afxVolume);
                    Raylib.SetSoundVolume(menuSelect, afxVolume);

                    Raylib.SetMusicVolume(menuMusic, musicVolume);
                    Raylib.SetMusicVolume(gameMusic, musicVolume);


                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN))
                    {

                        Raylib.PlaySound(menuSelect);

                        menu++;

                    }

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
                    {

                        Raylib.PlaySound(menuSelect);

                        menu--;

                    }


                    Raylib.BeginDrawing();

                    if (menu == 0)
                    {

                        Raylib.DrawText("<", 500, 300, 32, Color.WHITE);

                    }

                    if (menu == 1)
                    {

                        Raylib.DrawText("<", 500, 350, 32, Color.WHITE);

                    }

                    if (menu == 2)
                    {

                        Raylib.DrawText("<", 500, 400, 32, Color.WHITE);

                    }

                    if (menu == 0 && Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {

                        Raylib.PlaySound(menuEnter);

                        scene = "game";
                    }

                    if (menu == 1 && Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {

                        Raylib.PlaySound(menuEnter);

                        scene = "options";
                    }

                    if (menu == 2 && Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {

                        Raylib.PlaySound(menuExit);

                        Raylib.CloseWindow();

                        return;
                    }

                    if (menu > 2)
                    {

                        menu = 2;
                    }

                    if (menu < 0)
                    {

                        menu = 0;
                    }

                    Raylib.ClearBackground(Color.PURPLE);

                    Raylib.DrawText("Text", 240, 100, 128, Color.WHITE);

                    Raylib.DrawText("Start Game", width / 3 + 20, 300, 32, Color.WHITE);
                    Raylib.DrawText("Options", width / 3 + 20, 350, 32, Color.WHITE);
                    Raylib.DrawText("Quit", width / 3 + 20, 400, 32, Color.WHITE);

                    Raylib.EndDrawing();
                }

            }

        }

    }

    class DamageMaker
    {
        public static int StrikeDamage(int damage)
        {
            return damage % 15;
        }

        public static int MagicDamage(int magic)
        {
            return magic % 15 * 2;
        }
    }

}

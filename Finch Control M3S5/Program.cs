using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Talent Show S1
    // Description: Application designed to show off the light and sound functionalities of the Finch robot.
    // Application Type: Console
    // Author: Max Mackin
    // Dated Created: 2/16/21
    //
    // **************************************************

    public enum Command
    {
        NONE,
        MOVEFORWARD,
        MOVEBACKWARD,
        STOPMOTORS,
        WAIT,
        TURNRIGHT,
        TURNLEFT,
        LEDON,
        LEDOFF,
        GETTEMPERATURE,
        DONE
    }
    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
            DisplayReadAndSetTheme();
            DisplaySetNewTheme();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = false;

            bool QuitApplication = false;
            string MenuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("\tMain Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect the Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect the Finch Robot");
                Console.WriteLine("\tg) Quit application");
                Console.WriteLine("\t0) Theme customization");
                Console.Write("\tEnter menu Choice:");
                MenuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (MenuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":
                        LightAlarmDisplayMenuScreen(finchRobot);
                        break;

                    case "e":
                        UserProgrammingDisplayMenuScreen(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "g":
                        DisplayDisconnectFinchRobot(finchRobot);
                        QuitApplication = true;
                        break;

                    case "0":
                        DisplaySetNewTheme();
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a corresponding letter to choose a menu");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!QuitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void TalentShowDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool QuitTalentShowMenu = false;
            string MenuChoice;

            do
            {
                DisplayScreenHeader("\tTalent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Lights, Sounds, and Movement");
                Console.WriteLine("\tb) Main Menu");
                Console.Write("\tEnter Choice:");
                MenuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (MenuChoice)
                {
                    case "a":
                        TalentShowDisplay(finchRobot);
                        break;

                    case "b":
                        QuitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!QuitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplay(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Lights, Sounds, and Movement");

            Console.WriteLine("\tThe Finch robot will now demonstrate its wonderous abilities!");
            DisplayContinuePrompt();

            //
            //Show off LED control
            //

            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(1000);
            finchRobot.setLED(255, 255, 255);
            finchRobot.wait(1000);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(1000);
            finchRobot.setLED(0, 0, 0);
            finchRobot.wait(2000);

            //
            // Show off sound control, play happy birthday.
            //

            finchRobot.noteOn(784); //G5
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(784); //G5
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(880); //A5
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(784); //G5
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(1047); //C6
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(988); //B5
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(784); //G5
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(784); //G5
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(880); //A5
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(784); //G5
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(1174); //D6 
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(1047); //C6
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(784); //G5
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(784); //G5
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(1567); //G6
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(1318); //E6
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(1047); //C6
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(987); //B5
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(880); //A5
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(1396); //F6
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(1396); //F6
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(1318); //E6
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(1047); //C6
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(1174); //D6 
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(500);

            finchRobot.noteOn(1047); //C6
            finchRobot.wait(100);
            finchRobot.noteOff();
            finchRobot.wait(2000);

            //
            // Show off motor control
            //

            finchRobot.setMotors(100, 100);
            finchRobot.wait(3000);
            finchRobot.setMotors(0, 0);
            finchRobot.wait(3000);

            finchRobot.setLED(255, 0, 255);
            finchRobot.noteOn(659);
            finchRobot.setMotors(255, 255);
            finchRobot.wait(1500);
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();
            finchRobot.setMotors(0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }

        #endregion

        #region Data Recorder

        static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {
            int NumberOfDataPoints = 0;
            double FrequencyOfData = 0;
            double[] temperatures = null;

            Console.CursorVisible = false;

            bool QuitDataRecorderMenu = false;
            string MenuChoice;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of data points");
                Console.WriteLine("\tb) Frequency of data");
                Console.WriteLine("\tc) Get data");
                Console.WriteLine("\td) Show data");
                Console.WriteLine("\te) Main menu");
                Console.WriteLine("\tEnter menu choice: ");
                MenuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (MenuChoice)
                {
                    case "a":
                        NumberOfDataPoints = DataRecorderGetNumberOfDataPoints();
                        break;

                    case "b":
                        FrequencyOfData = DataRecorderGetFrequencyOfData();
                        break;

                    case "c":
                        temperatures = DataRecorderGetData(NumberOfDataPoints, FrequencyOfData, finchRobot);
                        break;

                    case "d":
                        DataRecorderGetData(temperatures);
                        break;

                    case "e":
                        QuitDataRecorderMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!QuitDataRecorderMenu);
        }

        static int DataRecorderGetNumberOfDataPoints()
        {
            int NumberOfDataPoints;
            string UserResponse;

            DisplayScreenHeader("Number of data points");

            Console.WriteLine("\tNumber of data points: ");
            UserResponse = Console.ReadLine();
            int.TryParse(UserResponse, out NumberOfDataPoints);

            DisplayContinuePrompt();
            return NumberOfDataPoints;
        }

        static double DataRecorderGetFrequencyOfData()
        {
            double FrequencyOfDataPoints;

            DisplayScreenHeader("Frequency of data");

            Console.WriteLine("\tFrequency of data: ");
            double.TryParse(Console.ReadLine(), out FrequencyOfDataPoints);

            DisplayContinuePrompt();
            return FrequencyOfDataPoints;
        }

        static double[] DataRecorderGetData(int NumberOfDataPoints, double FrequencyOfData, Finch finchRobot)
        {
            DisplayScreenHeader("Get Data");

            double[] temperatures = new double[NumberOfDataPoints];

            Console.WriteLine($"\tNumber of data points: {NumberOfDataPoints}");
            Console.WriteLine($"\tFrequency of data: {FrequencyOfData}");
            Console.WriteLine();
            Console.WriteLine("The finch robot is now ready to record temperature in fahrenheit");
            DisplayContinuePrompt();

            for (int index = 0; index < NumberOfDataPoints; index++)
            {
                temperatures[index] = finchRobot.getTemperature();
                temperatures[index] = temperatures[index] * 9.0 / 5.0 + 32.0;
                Console.WriteLine($"\tReading {index + 1}: {temperatures[index].ToString("n2")}");
                int WaitInSeconds = (int)(FrequencyOfData * 1000);
                finchRobot.wait(WaitInSeconds);
            }

            DisplayContinuePrompt();
            return temperatures;
        }
        static void DataRecorderGetData(double[] temperatures)
        {
            DisplayScreenHeader("Show data");

            Console.WriteLine(
                "Recording #".PadLeft(15) +
                "Temp(F)".PadLeft(15)
                );
            Console.WriteLine(
                "**********".PadLeft(15) +
                "**********".PadLeft(15)
                );

            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                    (index + 1).ToString().PadLeft(15) +
                    temperatures[index].ToString("n2").PadLeft(15)
                    );
            }

            DisplayContinuePrompt();
        }

        #endregion

        #region Alarm System

        static void LightAlarmDisplayMenuScreen(Finch finchRobot)
        {

            Console.CursorVisible = false;

            bool QuitDataRecorderMenu = false;
            string MenuChoice;

            string SensorsToMonitor = "";
            string RangeType = "";
            int MinMaxThresholdValue = 0;
            int TimeToMonitor = 0;

            do
            {
                DisplayScreenHeader("Light Alarm Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set sensors to monitor");
                Console.WriteLine("\tb) Set range type");
                Console.WriteLine("\tc) Set minimum/maximum thershold value");
                Console.WriteLine("\td) Set time to monitor");
                Console.WriteLine("\te) Set Light Alarm");
                //Console.WriteLine("\tf) Set temp Alarm");
                //Console.WriteLine("\tg) Set temp and light alarm");
                Console.WriteLine("\tf) Main menu");
                Console.WriteLine("\tEnter menu choice: ");
                MenuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (MenuChoice)
                {
                    case "a":
                        SensorsToMonitor = LightAlarmDisplaySetSensorsToMonitor();
                        break;

                    case "b":
                        RangeType = LightAlarmDisplaySetRangeType();
                        break;

                    case "c":
                        MinMaxThresholdValue = LightAlarmSetMinMaxThresholdValue(RangeType, finchRobot);
                        break;

                    case "d":
                        TimeToMonitor = LightAlarmSetTimeToMonitor();
                        break;

                    case "e":
                        LigthAlarmSetAlarm(finchRobot, SensorsToMonitor, RangeType, MinMaxThresholdValue, TimeToMonitor);
                        break;

                    //case "f":
                    //    TempAlarmSetAlarm(finchRobot, RangeType, MinMaxThresholdValue, TimeToMonitor);
                    //    break;

                    //case "g":

                    //    break;

                    case "f":
                        QuitDataRecorderMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!QuitDataRecorderMenu);
        }

        static string LightAlarmDisplaySetSensorsToMonitor()
        {
            string SensorsToMonitor;

            do
            {
                Console.Clear();
                DisplayScreenHeader("Sensors to monitor");
                Console.WriteLine("\tSensors to monitor [left, right, both]:");
                SensorsToMonitor = Console.ReadLine().ToLower();

                if (SensorsToMonitor != "left" && SensorsToMonitor != "right" && SensorsToMonitor != "both")
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a valid input, press any key to try again");
                    Console.ReadKey();
                }

            } while (SensorsToMonitor != "left" && SensorsToMonitor != "right" && SensorsToMonitor != "both");

            Console.WriteLine();
            Console.WriteLine($"\tSensor chosen: {SensorsToMonitor}.");

            DisplayMenuPrompt("Light Alarm");

            return SensorsToMonitor;
        }

        static string LightAlarmDisplaySetRangeType()
        {
            string RangeType;

            do
            {
                Console.Clear();
                DisplayScreenHeader("Range Type");
                Console.WriteLine("\tRange Type [minimum, maximum]:");
                RangeType = Console.ReadLine().ToLower();

                if (RangeType != "minimum" && RangeType != "maximum")
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a valid input, press any key to try again");
                    Console.ReadKey();
                }

            } while (RangeType != "minimum" && RangeType != "maximum");

            Console.WriteLine();
            Console.WriteLine($"\tRange type: {RangeType}.");

            DisplayMenuPrompt("Light Alarm");

            return RangeType;
        }

        static int LightAlarmSetMinMaxThresholdValue(string RangeType, Finch finchRobot)
        {
            int MinMaxThresholdValue;

            do
            {
                Console.Clear();
                DisplayScreenHeader("Min/Max Threshold Value");
                Console.WriteLine($"\tLeft light sensor ambient value: {finchRobot.getLeftLightSensor()}");
                Console.WriteLine($"\tRight light sensor ambient value: {finchRobot.getRightLightSensor()}");
                Console.WriteLine();

                Console.WriteLine($"\tEnter the {RangeType} light sensor value: ");
                int.TryParse(Console.ReadLine(), out MinMaxThresholdValue);

                if (MinMaxThresholdValue < 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a positive threshold value, press any key to continue.");
                    Console.ReadKey();
                }
            } while (MinMaxThresholdValue < 0);

            Console.WriteLine();
            Console.WriteLine($"\tMin/Max threshold value: {MinMaxThresholdValue}");

            DisplayMenuPrompt("Light Alarm");

            return MinMaxThresholdValue;
        }

        static int LightAlarmSetTimeToMonitor()
        {
            int SetTimeToMonitor;

            do
            {
                Console.Clear();
                DisplayScreenHeader("TimeToMonitor");
                Console.WriteLine($"\tTime to monitor: ");
                int.TryParse(Console.ReadLine(), out SetTimeToMonitor);

                if (SetTimeToMonitor < 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a positive time value, press any key to continue.");
                    Console.ReadKey();
                }
            } while (SetTimeToMonitor < 0);

            Console.WriteLine();
            Console.WriteLine($"\tTime to monitor: {SetTimeToMonitor}");

            DisplayMenuPrompt("Light Alarm");

            return SetTimeToMonitor;
        }

        static void LigthAlarmSetAlarm(Finch finchRobot, string SensorsToMonitor, string RangeType, int MinMaxThresholdValue, int TimeToMonitor)
        {
            int SecondsElapsed = 0;
            int CurrentLightSensorValue = 0;
            bool ThresholdExceeded = false;


            DisplayScreenHeader("Set Light Alarm");

            Console.WriteLine($"\tSensors to monitor: {SensorsToMonitor}");
            Console.WriteLine($"\tRange type: {RangeType}");
            Console.WriteLine($"\tMin/Max threshold value: {MinMaxThresholdValue}");
            Console.WriteLine($"\tTime to monitor: {TimeToMonitor}");
            Console.WriteLine();

            Console.WriteLine("\tPress any key to begin");
            Console.ReadKey();
            Console.WriteLine();

            while (SecondsElapsed < TimeToMonitor && !ThresholdExceeded)
            {
                switch (SensorsToMonitor)
                {
                    case "left":
                        CurrentLightSensorValue = finchRobot.getLeftLightSensor();
                        break;

                    case "right":
                        CurrentLightSensorValue = finchRobot.getRightLightSensor();
                        break;

                    case "both":
                        CurrentLightSensorValue = (finchRobot.getLeftLightSensor() + finchRobot.getRightLightSensor()) / 2;
                        break;
                }

                switch (RangeType)
                {
                    case "minimum":
                        if (CurrentLightSensorValue < MinMaxThresholdValue)
                        {
                            ThresholdExceeded = true;
                        }
                        break;

                    case "maxmimum":
                        if (CurrentLightSensorValue > MinMaxThresholdValue)
                        {
                            ThresholdExceeded = true;
                        }
                        break;
                }
                finchRobot.wait(1000);
                SecondsElapsed++;
            }

            if (ThresholdExceeded)
            {
                Console.WriteLine($"The {RangeType} threshold value of {MinMaxThresholdValue} was exceeded by the current light sensor values of {CurrentLightSensorValue}.");
            }
            else
            {
                Console.WriteLine($"The {RangeType} threshold value of {MinMaxThresholdValue} was not exceeded.");
            }

            DisplayMenuPrompt("Light Alarm");
        }

        //**************************************************************************************************************************
        // BELOW IS A FAILED ATTEMPT AT CREATING TEMPERATURE ALARM SYSTEM
        // Could not figure out why temperature value kept returning as 0 and thus the alarm would not function properly. 
        //**************************************************************************************************************************

        //static void TempAlarmSetAlarm(Finch finchRobot, string RangeType, int MinMaxThresholdValue, int TimeToMonitor)
        //{
        //    int SecondsElapsed = 0;
        //    double CurrentTempValue = finchRobot.getTemperature();
        //    bool ThresholdExceeded = false;


        //    DisplayScreenHeader("Set Temp Alarm");

        //    Console.WriteLine($"\tRange type: {RangeType}");
        //    Console.WriteLine($"\tMin/Max threshold value: {MinMaxThresholdValue}");
        //    Console.WriteLine($"\tTime to monitor: {TimeToMonitor}");
        //    Console.WriteLine();

        //    Console.WriteLine("\tPress any key to begin");
        //    Console.ReadKey();
        //    Console.WriteLine();

        //    while (SecondsElapsed < TimeToMonitor && !ThresholdExceeded)
        //    {
        //        CurrentTempValue = finchRobot.getTemperature();

        //        switch (RangeType)
        //        {
        //            case "minimum":
        //                CurrentTempValue = finchRobot.getTemperature();
        //                //CurrentTempValue = CurrentTempValue * 9.0 / 5.0 + 32.0;

        //                if (CurrentTempValue < MinMaxThresholdValue)
        //                {
        //                    ThresholdExceeded = true;
        //                }
        //                break;

        //            case "maxmimum":
        //                CurrentTempValue = finchRobot.getTemperature();
        //                //CurrentTempValue = CurrentTempValue * 9.0 / 5.0 + 32.0;

        //                if (CurrentTempValue > MinMaxThresholdValue)
        //                {
        //                    ThresholdExceeded = true;
        //                }
        //                break;
        //        }
        //        finchRobot.wait(1000);
        //        SecondsElapsed++;
        //    }

        //    if (ThresholdExceeded)
        //    {
        //        Console.WriteLine($"The {RangeType} threshold value of {MinMaxThresholdValue} was exceeded by the current temp value of {CurrentTempValue}.");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"The {RangeType} threshold value of {MinMaxThresholdValue} was not exceeded.");
        //    }

        //    DisplayMenuPrompt("Light Alarm");
        //}


        #endregion

        #region User Programming

        static void UserProgrammingDisplayMenuScreen(Finch finchRobot)
        {
            string MenuChoice;
            bool QuitMenu = false;

            (int MotorSpeed, int LedBrightness, double WaitInSeconds) CommandParameters;
            CommandParameters.MotorSpeed = 0;
            CommandParameters.LedBrightness = 0;
            CommandParameters.WaitInSeconds = 0;

            List<Command> commands = new List<Command>();

            do
            {
                DisplayScreenHeader("User Programming Menu");

                Console.WriteLine("\ta) Set Command Parameters");
                Console.WriteLine("\tb) Add Commands");
                Console.WriteLine("\tc) View Commands");
                Console.WriteLine("\td) Execute Commands");
                Console.WriteLine("\te) Quit");
                Console.Write("\tEnter menu Choice:");
                MenuChoice = Console.ReadLine().ToLower();


                switch (MenuChoice)
                {
                    case "a":
                        CommandParameters = UserProgrammingGetCommandParameters();
                        break;

                    case "b":
                        UserProgrammingGetFinchCommands(commands);
                        break;

                    case "c":
                        UserProgrammingDisplayFinchCommands(commands);
                        break;

                    case "d":
                        UserProgrammingExecuteFinchCommands(finchRobot, commands, CommandParameters);
                        break;

                    case "e":
                        QuitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a corresponding letter to choose a menu");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!QuitMenu);
        }

        static (int MotorSpeed, int LedBrightness, double WaitInSeconds) UserProgrammingGetCommandParameters()
        {
            DisplayScreenHeader("Command Parameters");

            (int MotorSpeed, int LedBrightness, double WaitInSeconds) CommandParameters;
            CommandParameters.MotorSpeed = 0;
            CommandParameters.LedBrightness = 0;
            CommandParameters.WaitInSeconds = 0;

            Console.WriteLine("\tEnter motor speed [1-255]: ");
            bool ParsedSuccessfully1 = int.TryParse(Console.ReadLine(), out CommandParameters.MotorSpeed);
            Console.WriteLine("\tEnter LED brightness [1-255]: ");
            bool ParsedSuccessfully2 = int.TryParse(Console.ReadLine(), out CommandParameters.LedBrightness);
            Console.WriteLine("\tEnter wait in seconds [1-255]: ");
            bool ParsedSuccessfully3 = double.TryParse(Console.ReadLine(), out CommandParameters.WaitInSeconds);

            if (ParsedSuccessfully1 == false)
            {
                Console.WriteLine("Please enter a valid integer for motor speed");
            }
            else
            {
                Console.WriteLine("Motor speed accepted");
            }


            if (ParsedSuccessfully2 == false)
            {
                Console.WriteLine("Please enter a valid integer for LED brightness");
            }
            else
            {
                Console.WriteLine("LED brightness accepted");
            }

            if (ParsedSuccessfully3 == false)
            {
                Console.WriteLine("Please enter a valid integer for wait time in seconds");
            }
            else
            {
                Console.WriteLine("Wait in second time accepted");
            }

            Console.WriteLine();
            Console.WriteLine($"\tMotor Speed: {CommandParameters.MotorSpeed}");
            Console.WriteLine($"\tLED Brightness: {CommandParameters.LedBrightness}");
            Console.WriteLine($"\tWait Duration: {CommandParameters.WaitInSeconds}");

            DisplayMenuPrompt("User Programming");

            return CommandParameters;
        }

        static void UserProgrammingGetFinchCommands(List<Command> commands)
        {
            Command command = Command.NONE;

            DisplayScreenHeader("Finch Robot Commands");

            int CommandCount = 1;
            Console.WriteLine("\tList of availble commands");
            Console.WriteLine();
            Console.WriteLine("\t=");

            foreach (string CommandName in Enum.GetNames(typeof(Command)))
            {
                Console.WriteLine($"- {CommandName.ToLower()}");
                if (CommandCount % 5 == 0) Console.Write("-\n\t-");
                CommandCount++;
            }
            Console.WriteLine();

            while (command != Command.DONE)
            {
                Console.WriteLine("\tEnter command:");

                if (Enum.TryParse(Console.ReadLine().ToUpper(), out command))
                {
                    commands.Add(command);
                }
                else
                {
                    Console.WriteLine("\t******************************************");
                    Console.WriteLine("\tPlease enter a command from the list above");
                    Console.WriteLine("\t******************************************");
                }
            }

            DisplayMenuPrompt("User Programming");
        }

        static void UserProgrammingDisplayFinchCommands(List<Command> commands)
        {
            DisplayScreenHeader("Finch Robot Commands");

            foreach (Command command in commands)
            {
                Console.WriteLine($"\t{command}");
            }

            DisplayMenuPrompt("User Programming");
        }

        static void UserProgrammingExecuteFinchCommands(Finch finchRobot, List<Command> commands, (int MotorSpeed, int LedBrightness, double WaitSeconds) CommandParameters)
        {
            int MotorSpeed = CommandParameters.MotorSpeed;
            int LedBrightness = CommandParameters.LedBrightness;
            int WaitInMilliSeconds = (int)(CommandParameters.WaitSeconds * 1000);
            string CommandFeedback = "";
            const int TURNING_MOTOR_SPEED = 100;

            DisplayScreenHeader("Execute Finch Commands");

            Console.WriteLine("The Finch robot is ready to execute the list of given commands");
            DisplayContinuePrompt();

            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.NONE:
                        break;

                    case Command.MOVEFORWARD:
                        finchRobot.setMotors(MotorSpeed, MotorSpeed);
                        CommandFeedback = Command.MOVEFORWARD.ToString();
                        break;

                    case Command.MOVEBACKWARD:
                        finchRobot.setMotors(MotorSpeed, MotorSpeed);
                        CommandFeedback = Command.MOVEBACKWARD.ToString();
                        break;

                    case Command.STOPMOTORS:
                        finchRobot.setMotors(0, 0);
                        CommandFeedback = Command.STOPMOTORS.ToString();
                        break;

                    case Command.WAIT:
                        finchRobot.wait(WaitInMilliSeconds);
                        CommandFeedback = Command.WAIT.ToString();
                        break;

                    case Command.TURNRIGHT:
                        finchRobot.setMotors(TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                        CommandFeedback = Command.TURNRIGHT.ToString();
                        break;

                    case Command.TURNLEFT:
                        finchRobot.setMotors(TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                        CommandFeedback = Command.TURNLEFT.ToString();
                        break;

                    case Command.LEDON:
                        finchRobot.setLED(LedBrightness, LedBrightness, LedBrightness);
                        CommandFeedback = Command.LEDON.ToString();
                        break;

                    case Command.LEDOFF:
                        finchRobot.setLED(0, 0, 0);
                        CommandFeedback = Command.LEDOFF.ToString();
                        break;

                    case Command.GETTEMPERATURE:
                        CommandFeedback = $"Temperature: {finchRobot.getTemperature().ToString("n2")}\n";
                        break;

                    case Command.DONE:
                        CommandFeedback = Command.DONE.ToString();
                        break;

                    default:

                        break;
                }

                Console.WriteLine($"\t{CommandFeedback}");
            }
            DisplayMenuPrompt("User Programming");
        }



        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Robot");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using the Finch robot!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion

        #region FileIO
        static void DisplayReadAndSetTheme()
        {
            (ConsoleColor ForegroundColor, ConsoleColor BackgroundColor) ThemeColors;
            string FileIOStatusMessage;

            //
            // read theme from data and set theme
            //
            ThemeColors = ReadThemeDataExceptions(out FileIOStatusMessage);
            if (FileIOStatusMessage == "Complete")
            {
                Console.ForegroundColor = ThemeColors.ForegroundColor;
                Console.BackgroundColor = ThemeColors.BackgroundColor;
                Console.Clear();

                DisplayScreenHeader("Read Theme from Data File");
                Console.WriteLine("\n\tTheme read from data file.\n");
            }
            else
            {
                DisplayScreenHeader("Read Theme from Data File");
                Console.WriteLine("\n\tTheme not read from data file.");
                Console.WriteLine($"\t*** {FileIOStatusMessage} ***\n");
            }
            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Set New Console Theme Screen                 *
        /// *****************************************************************
        /// </summary>
        static void DisplaySetNewTheme()
        {
            (ConsoleColor ForegroundColor, ConsoleColor BackgroundColor) ThemeColors;
            bool ThemeChosen = false;
            string FileIOStatusMessage;

            DisplayScreenHeader("Set New Theme");

            Console.WriteLine($"\tCurrent foreground color: {Console.ForegroundColor}");
            Console.WriteLine($"\tCurrent background color: {Console.BackgroundColor}");
            Console.WriteLine();

            Console.Write("\tWould you like to change the current theme [ yes | no ]?");
            if (Console.ReadLine().ToLower() == "yes")
            {
                do
                {
                    //
                    // query the user for console colors
                    //
                    ThemeColors.ForegroundColor = GetConsoleColorFromUser("foreground");
                    ThemeColors.BackgroundColor = GetConsoleColorFromUser("background");

                    //
                    // set new theme
                    //
                    Console.ForegroundColor = ThemeColors.ForegroundColor;
                    Console.BackgroundColor = ThemeColors.BackgroundColor;
                    Console.Clear();
                    DisplayScreenHeader("Set Application Theme");
                    Console.WriteLine($"\tNew foreground color: {Console.ForegroundColor}");
                    Console.WriteLine($"\tNew background color: {Console.BackgroundColor}");

                    Console.WriteLine();
                    Console.Write("\tIs this the theme you would like?");
                    if (Console.ReadLine().ToLower() == "yes")
                    {
                        ThemeChosen = true;
                        FileIOStatusMessage = WriteThemeDataExceptions(ThemeColors.ForegroundColor, ThemeColors.BackgroundColor);
                        if (FileIOStatusMessage == "Complete")
                        {
                            Console.WriteLine("\n\tNew theme written to data file.\n");
                        }
                        else
                        {
                            Console.WriteLine("\n\tNew theme not written to data file.");
                            Console.WriteLine($"\t*** {FileIOStatusMessage} ***\n");
                        }
                    }

                } while (!ThemeChosen);
            }
            DisplayContinuePrompt();
        }

        /// <summary>
        /// get a console color from the user
        /// </summary>
        /// <param name="property">foreground or background</param>
        /// <returns>user's console color</returns>
        static ConsoleColor GetConsoleColorFromUser(string Property)
        {
            ConsoleColor ConsoleColor;
            bool ValidConsoleColor;

            do
            {
                Console.Write($"\tEnter a value for the {Property}:");
                ValidConsoleColor = Enum.TryParse<ConsoleColor>(Console.ReadLine(), true, out ConsoleColor);

                if (!ValidConsoleColor)
                {
                    Console.WriteLine("\n\t***** It appears you did not provide a valid console color. Please try again. *****\n");
                }
                else
                {
                    ValidConsoleColor = true;
                }

            } while (!ValidConsoleColor);

            return ConsoleColor;
        }

        /// <summary>
        /// read theme info to data file with try/catch block
        /// returning a file IO status message using an out parameter
        /// </summary>
        /// <returns>tuple of foreground and background</returns>
        static (ConsoleColor ForegroundColor, ConsoleColor BackgroundColor) ReadThemeDataExceptions(out string FileIOStatusMessage)
        {
            string DataPath = @"Theme.txt";
            string[] ThemeColors;

            ConsoleColor ForegroundColor = ConsoleColor.White;
            ConsoleColor BackgroundColor = ConsoleColor.Black;

            try
            {
                ThemeColors = File.ReadAllLines(DataPath);
                if (Enum.TryParse(ThemeColors[0], true, out ForegroundColor) &&
                    Enum.TryParse(ThemeColors[1], true, out BackgroundColor))
                {
                    FileIOStatusMessage = "Complete";
                }
                else
                {
                    FileIOStatusMessage = "Data file incorrectly formated.";
                }
            }
            catch (DirectoryNotFoundException)
            {
                FileIOStatusMessage = "Unable to locate the folder for the data file.";
            }
            catch (Exception)
            {
                FileIOStatusMessage = "Unable to read data file.";
            }

            return (ForegroundColor, BackgroundColor);
        }

        /// <summary>
        /// write theme info to data file with try/catch block
        /// returning a file IO status message using an out parameter
        /// </summary>
        /// <returns>tuple of foreground and background</returns>
        static string WriteThemeDataExceptions(ConsoleColor Foreground, ConsoleColor Background)
        {
            string DataPath = @"Theme.txt";
            string FileIOStatusMessage = "";

            try
            {
                File.WriteAllText(DataPath, Foreground.ToString() + "\n");
                File.AppendAllText(DataPath, Background.ToString());
                FileIOStatusMessage = "Complete";
            }
            catch (DirectoryNotFoundException)
            {
                FileIOStatusMessage = "Unable to locate the folder for the data file.";
            }
            catch (Exception)
            {
                FileIOStatusMessage = "Unable to write to data file.";
            }

            return FileIOStatusMessage;
        }
    }
        #endregion
    }

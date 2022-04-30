using System;

namespace _10_Passwordabfrage {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Password Abfrage");


            //Passwort validieren
            // 1) Mindestlänge
            // 2) Zahl
            // 3) Buchstabe Groß und Klein
            // 4) Sonderzeichen
            // 5) Keine Leerzeichen

            string password;
            int longEnough = 7;
            bool pwAccepted = false;
            int minLetters = 2;
            int minNumbers = 2;
            int minSonderzeichen = 2;

            do {

                int hasLetters = 0;
                int hasNumbers = 0;
                int hasSondezeichen = 0;
                bool hasBigLetter = false;
                bool hasSmallLetter = false;
                bool whiteSpace = false;
                string pwCheck;
                int pwLength;
                Console.WriteLine("\nBitte Passwort festlegen:");
                password = Console.ReadLine();
                pwLength = password.Length;
                for (int i = 0; i < pwLength; i++) {
                    if (Char.IsDigit(password[i])) {
                        hasNumbers++;
                    }
                    if (Char.IsLetter(password[i])) {
                        if (Char.IsUpper(password[i])) {
                            hasBigLetter = true;
                        }
                        if (Char.IsLower(password[i])) {
                            hasSmallLetter = true;
                        }
                        hasLetters++;
                    }
                    if (!Char.IsLetterOrDigit(password[i])) {
                        if (Char.IsWhiteSpace(password[i])) {
                            whiteSpace = true;
                        } else {
                            hasSondezeichen++;
                        }
                    }
                }
                Console.WriteLine();
                if (password.Length < 7) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Das Passwort muss mindestens {longEnough} Zeichen haben.");
                    Console.ResetColor();
                }
                if (hasNumbers < minNumbers) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Passwort muss mindestens {minNumbers} Zahlen enthalten!");
                    Console.ResetColor();
                }
                if (hasLetters < minLetters) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Passwort muss mindestens {minLetters} Buchstaben enthalten!");
                    Console.ResetColor();
                } else if (hasBigLetter == false) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Passwort muss mindestens einen Großbuchstaben enthalten!");
                    Console.ResetColor();
                } else if (hasSmallLetter == false) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Passwort muss mindestens einen Kleinbuchstaben enthalten!");
                    Console.ResetColor();
                }
                if (hasSondezeichen < minSonderzeichen) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Passwort muss mindestens {minSonderzeichen} Sonderzeichen enthalten!");
                    Console.ResetColor();
                }
                if (whiteSpace == true) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Passwort darf kein Leerzeichen enthalten!");
                    Console.ResetColor();

                }

                if (pwLength >= longEnough && hasNumbers >= minNumbers && hasLetters >= minLetters && hasSondezeichen >= minSonderzeichen && hasBigLetter == true && hasSmallLetter == true && whiteSpace == false) {
                    Console.WriteLine("\nBitte Passwort bestätigen:");
                    pwCheck = Console.ReadLine();
                    if (pwCheck == password) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nPasswort akzeptiert!");
                        pwAccepted = true;
                        Console.ResetColor();
                    } else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nPasswörter stimmen nicht überein, bitte wiederholen.");
                        Console.ResetColor();
                    }
                }
            } while (pwAccepted == false);

        }
    }
}


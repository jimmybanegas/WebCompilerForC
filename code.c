#include "header.h"
#include "Physics/Solver.h"
#include <stdio.h>


float average (int n_args, ...)
{
    
    char newline = '\n';
    char tab = '\t';
    char backspace = '\b';
    char backslash = '\\';
    char nullChar = '\0';
    char quot = '"';
   
    date my_date = #14-05-1993#;

    var mistr = "This\nis\na\ntest\n\nShe \"said, \"How are you?\"\n";

    va_list _myList;
    va_start (myList, n_args);
    
    int numbersAdded = 0;

    int sum = 23.45.;

    int hex = 0x3F7;

    int octal = 07;

    int number = 78;

    int n = 23e10;

    int n2 = 23e-5;


    while (numbersAdded < n_args) {
        int number = va_arg (myList, int); // Get next number from list
        sum += number;
        numbersAdded += 1;
    }
    va_end (myList);
         
    float avg = (float)(sum) / (float)(numbersAdded); // Find the average
    return avg;

      /* my first program in C */
   printf("Hello, World! \n");

   char[100] string = "mi cadena";

   string mistr =  "mi cadena ";

   float =  'a';
   
   return 0;

   /*
 * Comments blocks like this explain what the following code attempts
 * to do.  These comments often come directly from the design
 * statement.
 */

/// <summary>
/// Here is how to use the class: <![CDATA[ <test>Data</test> ]]>
/// </summary>

//"This\nis\na\ntest\n\nShe said, \"How are you?\"\n"

    int x;            /* A normal integer*/
    int *p;           /* A pointer to an integer ("*p" is an integer, so p
                       must be a pointer to an integer) */

    p = &x;           /* Read it, "assign the address of x to p" */
    scanf( "%d", &x );          /* Put a value in x, we could also use p here */
    printf( "%d\n", *p ); /* Note the use of the * to get the value */
    getchar();


    typedef enum {RANDOM, IMMEDIATE, SEARCH} strategy;
    strategy my_strategy = IMMEDIATE;

}
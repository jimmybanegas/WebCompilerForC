
<!DOCTYPE html>
<html>
<head>
<title>Page Title</title>
</head>
<body>
<div>
<h1>This is a Heading</h1>
<p>This is a paragraph.</p>

<%  
#include "header.h"
#include "Physics/Solver.h"

struct employee   /* Defines a structure variable named temp */  
{  
    char name[20];  
    int id;  
    long class;  
} temp;

struct employee student, faculty, staff;  
struct a var3;  
struct point *p ;

struct point *p = &my_point;  

struct point my_point = { 3, 7 };

// struct list_element {
//    point p;
//    list_element * next;
// };

int main() {
    int a = 60;	  // 60 = 0011 1100  
    int b = 13;	  // 13 = 0000 1101
   int c = 0;           

   c = a & b;             
   // 12 = 0000 1100
  // cout << "Line 1 - Value of c is : " << c << endl ;

   c = a | b;             // 61 = 0011 1101
  // cout << "Line 2 - Value of c is: " << c << endl ;

   c = a ^ b;             // 49 = 0011 0001
   //cout << "Line 3 - Value of c is: " << c << endl ;

   c = ~a;                // -61 = 1100 0011
   //cout << "Line 4 - Value of c is: " << c << endl ;

   c = a << 2;            // 240 = 1111 0000
   //cout << "Line 5 - Value of c is: " << c << endl ;

   c = a >> 2;            // 15 = 0000 1111
   //cout << "Line 6 - Value of c is: " << c << endl ;

   return 0;
}

float average (int n_args)
{    
    char newline = '\n'; 
    char tab = '\t';  
    char backspace = '\b'; 
    char backslash = '\\';   
    char nullChar = '\0'; 
    char quot = '"';
   
     date my_date = #14-05-1993#;
     string mistr = "This\nis\na\ntest\n\nShe \"said, \"How are you?\"\n"; 

    
    int numbersAdded = 3.0;   
    int sum = 23.45;  
    int hex = 0x3F7; 
    int octal = 07; 
    int number = 78;
    int n = 23e10;  
    int n2 = 23e-5;

    while (numbersAdded < n_args) {
       // int number = va_arg (myList, int); // Get next number from list
        sum += number;
        numbersAdded += 1;
    }
    va_end (myList);
         
   //float avg = (float)(sum) / (float)(numbersAdded); // Find the average
    return avg;

 /* my first program in C */
   printf("Hello, World! \n");   
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
    //typedef enum {RANDOM, IMMEDIATE, SEARCH} strategy;
    //strategy my_strategy = IMMEDIATE;

    bool existe = false;
    bool no_existe = true;
}


struct MyStruct {
     int   m_aNumber;
     float num2;
 };

struct Books {
   char  title[50];
   char  author[50];
   char  subject[100];
   int   book_id;
} book;  

char greeting[6] = {'H', 'e', 'l', 'l', 'o', '\0'};

char _temp;

extern int d = 3, f = 5;    // declaration of d and f. 
int d = 3, f = 5;           // definition and initializing d and f. 
//byte z = 22;                // definition and initializes z. 
char x = 'x';               // the variable x has the value 'x'.

// Variable declaration:
extern int a, b;
extern int c;
extern float f;

int main () {

   /* variable definition: */
   int a, b;
   int c;
   float f;
 
   /* actual initialization */
   a = 10;
   b = 20;

   a++;
   b--;
  
   c = a + b;
   printf("value of c : %d \n", c);

   f = 70.0/3.0;
   printf("value of f : %f \n", f);
 
   return 0;
}

  int numbersAdded = 3.0;

  int numbersAdded = 3.0;   int sum = 23.45;  int hex = 0x3F7; 
  int octal = 07; int number = 78; int n = 23E10;  int n2 = 23e-5;

  int a = 5;
   int b = 20;
   int c ;

   if ( a && b ) {
      printf("Line 1 - Condition is true\n" );
   }
	
   if ( a || b ) {
      printf("Line 2 - Condition is true\n" );
   }
   
   /* lets change the value of  a and b */
   a = 0;
   b = 10;
	
   if ( a && b ) {
      printf("Line 3 - Condition is true\n" );
   }
   else {
      printf("Line 3 - Condition is not true\n" );
   }
	
   if ( !(a && b) ) {
      printf("Line 4 - Condition is true\n" );
   }

int main() {
   int a = 21;
   int b = 10;
   int c ;

   if( a == b ) {
     // cout << "Line 1 - a is equal to b" << endl ;
   } else {
     // cout << "Line 1 - a is not equal to b" << endl ;
   }
	
   if ( a < b ) {
     // cout << "Line 2 - a is less than b" << endl ;
   } else {
    //cout << "Line 2 - a is not less than b" << endl ;
   }
	
   if ( a > b ) {
      //cout << "Line 3 - a is greater than b" << endl ;
   } else {
      //cout << "Line 3 - a is not greater than b" << endl ;
   }
	
   /* Let's change the values of a and b */
   a = 5;
   b = 20;
	
   if ( a <= b ) {
      //cout << "Line 4 - a is either less than \
       //  or euqal to  b" << endl ;
   }
	
   if ( b >= a ) {
    //   cout << "Line 5 - b is either greater than \
    //      or equal to b" << endl ;
   }
	
   return 0;
}


int main() {
   int a = 21;
   int b = 10;
   int c ;

   if( a == b ) {
      //cout << "Line 1 - a is equal to b" << endl ;
   } else {
      //cout << "Line 1 - a is not equal to b" << endl ;
   }
	
   if ( a < b ) {
      //cout << "Line 2 - a is less than b" << endl ;
   } else {
    //  cout << "Line 2 - a is not less than b" << endl ;
   }
	
   if ( a > b ) {
     // cout << "Line 3 - a is greater than b" << endl ;
   } else {
      //cout << "Line 3 - a is not greater than b" << endl ;
   }
	
   /* Let's change the values of a and b */
   a = 5;
   b = 20;
	
   if ( a <= b ) {
    //   cout << "Line 4 - a is either less than \
    //      or euqal to  b" << endl ;
   }
	
   if ( b >= a ) {
    //   cout << "Line 5 - b is either greater than \
    //      or equal to b" << endl ;
   }

   string mi_str = "prueba\
   dos";
	
   return 0;
}

int main() {
   int a = 21;
   int c ;

   c =  a;
   //cout << "Line 1 - =  Operator, Value of c = : " <<c<< endl ;

   c +=  a;
   //cout << "Line 2 - += Operator, Value of c = : " <<c<< endl ;

   c -=  a;
   //cout << "Line 3 - -= Operator, Value of c = : " <<c<< endl ;

   c *=  a;
   //cout << "Line 4 - *= Operator, Value of c = : " <<c<< endl ;

   c /=  a;
   //cout << "Line 5 - /= Operator, Value of c = : " <<c<< endl ;

   c  = 200;
   c %=  a;
   //cout << "Line 6 - %= Operator, Value of c = : " <<c<< endl ;

   c <<=  2;
   //cout << "Line 7 - <<= Operator, Value of c = : " <<c<< endl ;

   c >>=  2;
   //cout << "Line 8 - >>= Operator, Value of c = : " <<c<< endl ;

   c &=  2;
   //cout << "Line 9 - &= Operator, Value of c = : " <<c<< endl ;

   c ^=  2;
   //cout << "Line 10 - ^= Operator, Value of c = : " <<c<< endl ;

   c |=  2;
   //cout << "Line 11 - |= Operator, Value of c = : " <<c<< endl ;

   return 0;
}

int main() {

   int a = 4;
   double c;
   int* ptr;

   /* example of sizeof operator */

   /* example of & and * operators */
   ptr = &a;	/* 'ptr' now contains the address of 'a'*/
   printf("value of a is  %d\n", a);
   printf("*ptr is %d.\n", *ptr);

   /* example of ternary operator */
   a = 10;
  // b = (a == 1) ? 20: 30;
   printf( "Value of b is %d\n", b );

  // b = (a == 10) ? 20: 30;
   printf( "Value of b is %d\n", b );
}

int main() {

   int a = 21;
   int b = 10;
   int c ;

   c = a + b;
   printf("Line 1 - Value of c is %d\n", c );
	
   c = a - b;
   printf("Line 2 - Value of c is %d\n", c );
	
   c = a * b;
   printf("Line 3 - Value of c is %d\n", c );
	
   c = a / b;
   printf("Line 4 - Value of c is %d\n", c );
	
   c = a % b;
   printf("Line 5 - Value of c is %d\n", c );
	
   c = a++; 
   printf("Line 6 - Value of c is %d\n", c );
	
   c = a--; 
   printf("Line 7 - Value of c is %d\n", c );
}

%>

<div>
</body>
</html>
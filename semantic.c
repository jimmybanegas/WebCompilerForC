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


int ana = 20;

   int  var = 20;   /* actual variable declaration */
   int  *ip;        /* pointer variable declaration */

   ip = &var;  /* store address of var in pointer variable*/
  

struct student {
    date faltas[50];
    int  age;
    int  year;
    float  gpa;
};

struct student s;
struct student *sptr;
struct student students[36];  

s.age = 20;
s.faltas[1] = true;

double getAverage(int *arr, int size) {

   int  i, sum = 0;       
   double avg;          
 
   for (i = 0; i < size; ++i) {
      sum += arr;
      return;
   }

 
   avg = sum / size;
   
   return avg;
}

 
int main () {

   /* an int array with 5 elements */
   int balance[5] = {1000, 2, 3, 17, 50};
   double avg;
 
   /* pass pointer to the array as an argument */
//   avg = getAverage( balance, 5 ) ;
 
   /* output the returned value  */
   //printf("Average value is: %f\n", avg );

 int grade;

 switch(grade) {
      case 'A' :
        // printf("Excellent!\n" );
        int x = 0;
         break;
      case 'B' :
      case 'C' :
         //printf("Well done\n" );
         int x = 0;
         break;
      case 'D' :
         //printf("You passed\n" );
         int x = 0;
         break;
      case 'F' :
         //printf("Better try again\n" );
         int x = 0;
         break;
      default :
         //printf("Invalid grade\n" );
   }

   return 0;
}


int swap(int *x, int *y) {

   int temp;
   temp = *x;    /* save the value at address x */
   *x = *y;      /* put y into x */
   *y = &temp;    /* put temp into y */
  
   return 0;
}

int main2 () {

   /* local variable definition */
   int a = 100;
   int b = 200;
 
  // printf("Before swap, value of a : %d\n", a );
  // printf("Before swap, value of b : %d\n", b );
 
   /* calling a function to swap the values.
      * &a indicates pointer to a ie. address of variable a and 
      * &b indicates pointer to b ie. address of variable b.
   */
 int x =  swap(&a, &b);
 
  // printf("After swap, value of a : %d\n", a );
   //printf("After swap, value of b : %d\n", b );
 
   return 0;
}


  enum Security_Levels
        {
          black_ops,
          top_secret,
          secret,
          non_secret
        };       // don't forget the semi-colon ; 


struct Foo {
    int bar;
    int some_array[20];
};

 struct Foo foo;

bool f = true;


   int x;
 for ( x = 0; x < 10; x++ ) {
    /* Keep in mind that the loop condition checks 
        the conditional statement before it loops again.
        consequently, when x equals 10 the loop breaks.
        x is updated before the condition is checked. */ 
   string y = "hola";  
   
  continue;   
  //  printf( "%d\n", x );
   bool f = true;
 }

foo.some_array[1] = 12;

s.age = 18;
s.year = 2016;
s.gpa = 62.5;

sptr->age = 19;     // the age field of what sptr points to gets 20
sptr->year = 2015;
sptr->gpa = 3.2;

//students[2].name[2] = 'k' ;   

float  linearA[30];
 float *A[6];

 float *pf;


 long  myArray[20];
 long  *pArray;
 int  i;

 /* Assign values to the entries of myArray */
 pArray = myArray;
 for (i=0; i<10; ++i) {
   pArray++ = 5 + 3*i + 12*i*i;
   *pArray++ = 6 + 2*i + 7*i*i;
 }

 int FunctTwo( int *pStruct, int *mValue )
 {
    int j;
    long  AnArray[25];
    long *pAA;

    pAA = &AnArray[13];
    //j = FunctOne( pStruct, *mValue, pAA );
    return j;
 }

// FunctTwo();

struct Books {
  char  title[50];
  char  author[50];
  char  subject[100];
   int   book_id;
};

struct Books *personPtr;

void printBook( struct Books book ) {
    //book.book_id = 200;
}

   int n[ 10 ]; /* n is an array of 10 integers */
   int i_z,j;
   
   /* output each array element's value */
   for (j = 0; j < 10; j++ ) {
     // printf("Element[%d] = %d\n", j, n[j] );
     // date y ;
      int x = n[j];
   }

  /* initialize elements of array n to 0 */         
   for ( i_z = 0; i < 10; i++ ) {
     // date x;
      n[ i ] = i + 100; /* set element at location i to i + 100 */
   }
char cha,nplname[10], *ch , *plname[20] ;
 
int *xy[5];

//int myArray[10] = { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

int main3()                            /* Most important part of the program!  */
{
    int age;                          /* Need a variable... */

    //printf( "Please enter your age" );  /* Asks for age */
   // scanf( "%d", &age );                 /* The input is put in age */
    if ( age < 100 ) {                  /* If the age is less than 100 */
       // printf ("You are pretty young!\n" ); /* Just to show you it works... */
    }
    else if ( age == 100 ) {            /* I use else just to show an example */
      //  printf( "You are old\n" );
    }
    else {
       // printf( "You are really old\n" );     /* Executed if no other statement is */
    }

  return 0;
}

int DoSomethingNice( bool aVariable, int aFunction, int * hola )
{
    int rv = 0;

    if (aVariable < rv) {
    // rv = aFunction(aVariable, dataPointer );
    } else {

    //  rv = aFunction(aVariable, dataPointer );
    }

    date fecha = #01-01-1990#;
    return rv;
}

int DoSomething()
{
    int rv = 0;
     date fecha = #01-01-1990#;
    return rv;
}

 //date fecha = DoSomething();
 

//int x  = DoSomethingNice(1>5,5);
float y;
bool z;

struct Books2 {
   char  title[50];
   char  author[50];
   char  subject[100];
   int   book_id;
};

struct Books2 Book1; 

//Book1.author = true;
//Book1.otro = "hola";
Book1.title = "hola";

double balance[] = {1000.0, 2.0, 3.4, 7.0, 50.0};

balance[4] = 50.0;

void copy_array(float *src, float *dst, int n)
{
    while (n-- > 0) {
 // Loop that counts down from n to zero
        *dst++ = *src++;   // Copies element *(src) to *(dst),
                           //  then increments both pointers
    }
}


copy_array(&x,&y,&z);


const int ptr = 32.75; 

#include "prueba.h" 

enum DAY            /* Defines an enumeration type    */  
{  
    saturday ,       /* Names day and declares a       */  
    sunday = 0,     /* variable named workday with    */   
    monday,         /* that type                      */  
    tuesday,  
    wednesday,      /* wednesday is associated with 3 */  
    thursday,  
    friday  
} ;  

float KrazyFunction( int *parm1, bool p1size, int bb )
 {
   int ix; //declaring an integer variable//
   string y = "hola";
   for (ix=0; ix<p1size; ix++) {
     // if (parm1[ix].m_aNumber == bb )
       //   return parm1[ix].num2;
   }
   return 0;
 }

  while( 10 < 20 ) {
     // printf("value of a: %d\n", *a);
     // a++;
      const char x_const = 'x';  
   }

 int   someSize;
 int   ix;
 string xl = "hola";

 bool c = ix+someSize;

int x_z;   
bool f_x = false;

for ( x = 0; x < 10; x++ ) {
    /* Keep in mind that the loop condition checks 
        the conditional statement before it loops again.
        consequently, when x equals 10 the loop breaks.
        x is updated before the condition is checked. */ 
       // string y = "hola";  
  //  printf( "%d\n", x );
   bool f = true;

   f = false;
}


for (string item : someList) {
   item = 65;
   int someSize;
}

float v3;


 if (someSize > 0){
    float v3;
    int x;
 }


/* The loop goes while x < 10, and x increases by one every loop*/
for ( x = 0; x < 10; x++ ) {
    /* Keep in mind that the loop condition checks 
        the conditional statement before it loops again.
        consequently, when x equals 10 the loop breaks.
        x is updated before the condition is checked. */ 
   string y = "hola";  
  //  printf( "%d\n", x );
   bool f = true;
}
 
  string xyz = "hola";  
  ch = ix+someSize;


%>

<div>
</body>
</html>
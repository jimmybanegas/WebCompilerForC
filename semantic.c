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


  enum Security_Levels
        {
          black_ops,
          top_secret,
          secret,
          non_secret
        };       // don't forget the semi-colon ; 
        
// int main()
// {
//     enum week today;
//     today = wednesday;
//     printf("Day %d",today+1);
//     return 0;
// }


struct student {
    char name[50];
    int  age;
    int  year;
    float  gpa;
};

struct student s;
struct student *sptr;
struct student students[36];  

// struct Foo {
//     int bar;
//     int some_array[20];
// };

 //struct Foo foo;

   bool f = true;

   int x;
 for ( x = 0; x < 10; x++ ) {
    /* Keep in mind that the loop condition checks 
        the conditional statement before it loops again.
        consequently, when x equals 10 the loop breaks.
        x is updated before the condition is checked. */ 
   string y = "hola";  
  //  printf( "%d\n", x );
   bool f = true;
 }
//foo.some_array[0] = 12;

s.age = 18;
s.year = 2016;
s.gpa = 4.0;

// sptr->age = 19;     // the age field of what sptr points to gets 20
// sptr->year = 2015;
// sptr->gpa = 3.2;

//students[2].name[2] = 'k' ;   

// float  linearA[30];
//  float *A[6];

//  float *pf;


//  long  myArray[20];
//  long  *pArray;
//  int  i;

//  /* Assign values to the entries of myArray */
//  pArray = myArray;
//  for (i=0; i<10; ++i) {
//    pArray++ = 5 + 3*i + 12*i*i;
//    *pArray++ = 6 + 2*i + 7*i*i;
//  }

//  int FunctTwo( int *pStruct, int *mValue )
//  {
//     int j;
//     long  AnArray[25];
//     long *pAA;

//     pAA = &AnArray[13];
//     //j = FunctOne( pStruct, *mValue, pAA );
//     return j;
//  }

// struct Books {
//  //  char  title[50];
//  //  char  author[50];
//  //  char  subject[100];
//    int   book_id;
// };

// //struct Books *personPtr, person1;

// void printBook( struct Books book ) {
//    int a = book.book_id;
// }

//    int n[ 10 ]; /* n is an array of 10 integers */
//    int i_z,j;
   
//    /* output each array element's value */
//    for (j = 0; j < 10; j++ ) {
//      // printf("Element[%d] = %d\n", j, n[j] );
//      // date y ;
//       int x = n[j];
//    }

//   /* initialize elements of array n to 0 */         
//    for ( i_z = 0; i < 10; i++ ) {
//      // date x;
//       n[ i ] = i + 100; /* set element at location i to i + 100 */
//    }
// char cha,nplname[10], *ch , *plname[20] ;
 
// int *xy[5];

// //int myArray[10] = { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

// int main()                            /* Most important part of the program!  */
// {
//     int age;                          /* Need a variable... */

//     //printf( "Please enter your age" );  /* Asks for age */
//    // scanf( "%d", &age );                 /* The input is put in age */
//     if ( age < 100 ) {                  /* If the age is less than 100 */
//        // printf ("You are pretty young!\n" ); /* Just to show you it works... */
//     }
//     else if ( age == 100 ) {            /* I use else just to show an example */
//       //  printf( "You are old\n" );
//     }
//     else {
//        // printf( "You are really old\n" );     /* Executed if no other statement is */
//     }

//   return 0;
// }

// int DoSomethingNice( bool aVariable, int aFunction, int * hola )
// {
//     int rv = 0;

//     if (aVariable < rv) {
//     // rv = aFunction(aVariable, dataPointer );
//     } else {

//     //  rv = aFunction(aVariable, dataPointer );
//     }

//     date fecha = #01-01-1990#;
//     return rv;
// }

// int DoSomething()
// {
//     int rv = 0;
//      date fecha = #01-01-1990#;
//     return rv;
// }

//  //date fecha = DoSomething();
 

// //int x  = DoSomethingNice(1>5,5);
// float y;
// bool z;

// struct Books2 {
//    char  title[50];
//    char  author[50];
//    char  subject[100];
//    int   book_id;
// };

// struct Books2 Book1; 

// //Book1.author = true;
// //Book1.otro = "hola";
// Book1.title = "hola";

// double balance[] = {1000.0, 2.0, 3.4, 7.0, 50.0};

// balance[4] = 50.0;

// void copy_array(float *src, float *dst, int n)
// {
//     while (n-- > 0) {
//  // Loop that counts down from n to zero
//         *dst++ = *src++;   // Copies element *(src) to *(dst),
//                            //  then increments both pointers
//     }
// }


// copy_array(x,y,z);


// const int ptr = 32.75; 

// ptr = 23;

// #include "prueba.h" 

// enum DAY            /* Defines an enumeration type    */  
// {  
//     saturday ,       /* Names day and declares a       */  
//     sunday = 0,     /* variable named workday with    */   
//     monday,         /* that type                      */  
//     tuesday,  
//     wednesday,      /* wednesday is associated with 3 */  
//     thursday,  
//     friday  
// } ;  

// float KrazyFunction( int *parm1, bool p1size, int bb )
//  {
//    int ix; //declaring an integer variable//
//    string y = "hola";
//    for (ix=0; ix<p1size; ix++) {
//      // if (parm1[ix].m_aNumber == bb )
//        //   return parm1[ix].num2;
//    }
//    return 0;
//  }

//   while( 10 < 20 ) {
//      // printf("value of a: %d\n", *a);
//      // a++;
//       const char x_const = 'x';  
//    }

//  int   someSize;
//  int   ix;
//  string xl = "hola";

//  bool c = ix+someSize;

// int x_z;   
// bool f = false;

// for ( x = 0; x < 10; x++ ) {
//     /* Keep in mind that the loop condition checks 
//         the conditional statement before it loops again.
//         consequently, when x equals 10 the loop breaks.
//         x is updated before the condition is checked. */ 
//        // string y = "hola";  
//   //  printf( "%d\n", x );
//    bool f = true;

//    f = false;
// }


// for (string item : someList) {
//    item = 65;
//    int someSize;
// }

// float v3;


//  if (someSize > 0){
//     float v3;
//     int x;
//  }


// /* The loop goes while x < 10, and x increases by one every loop*/
// for ( x = 0; x < 10; x++ ) {
//     /* Keep in mind that the loop condition checks 
//         the conditional statement before it loops again.
//         consequently, when x equals 10 the loop breaks.
//         x is updated before the condition is checked. */ 
//    string y = "hola";  
//   //  printf( "%d\n", x );
//    bool f = true;
// }
 
//    string y = "hola";  
//   ch = ix+someSize;


%>

<div>
</body>
</html>
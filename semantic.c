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

// int myArray[10] = { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

// int main()                            /* Most important part of the program!  */
// {
//     int age;                          /* Need a variable... */

//     printf( "Please enter your age" );  /* Asks for age */
//     scanf( "%d", &age );                 /* The input is put in age */
//     if ( age < 100 ) {                  /* If the age is less than 100 */
//         printf ("You are pretty young!\n" ); /* Just to show you it works... */
//     }
//     else if ( age == 100 ) {            /* I use else just to show an example */
//         printf( "You are old\n" );
//     }
//     else {
//         printf( "You are really old\n" );     /* Executed if no other statement is */
//     }
//   return 0;
// }

// int DoSomethingNice( bool aVariable, int aFunction, void *dataPointer )
// {
//     int rv = 0;

//     if (aVariable < rv) {
//     // rv = aFunction(aVariable, dataPointer );
//     } else {

//     //  rv = aFunction(aVariable, dataPointer );
//     }

//     return rv;
// }
 
void copy_array(float *src, float *dst, bool n)
{
    while (n-- > 0) {
 // Loop that counts down from n to zero
        *dst++ = *src++;   // Copies element *(src) to *(dst),
                           //  then increments both pointers
    }
}

int x ;
float y;
date z;

copy_array(x,y,z);

// struct Books {
//    char  title[50];
//    char  author[50];
//    char  subject[100];
//    int   book_id;
// };

// struct Books Book1; 

// Book1.book_id = true;
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


// const int ptr = 32.75; 

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
//       if (parm1[ix].m_aNumber == bb )
//           return parm1[ix].num2;
//    }
//    return 0;
//  }

//   while( 10 < 20 ) {
//       printf("value of a: %d\n", *a);
//      // a++;
//       const char x_const = 'x';  
//    }

//  int   someSize;
//  int   ix;
//  string xl = "hola";

//  bool c = ix+someSize;

// int x;   
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

// int myArray[10][2] = { 5, 3, 5, 5, 5, 5, 5, 5, 5, 5 };

// for (string item : someList) {
//    item = 65;
//    int someSize;
// }

// float v3;


//  if (someSize > 0){
//     float v3;
//     int x;
//  }

 
// int xy;

// /* The loop goes while x < 10, and x increases by one every loop*/
// for ( x = 0; x < 10; x++ ) {
//     /* Keep in mind that the loop condition checks 
//         the conditional statement before it loops again.
//         consequently, when x equals 10 the loop breaks.
//         x is updated before the condition is checked. */ 
//        // string y = "hola";  
//   //  printf( "%d\n", x );
//  //  bool f = true;
// }
 

//  char cha,nplname[20],ch ,plname[20] ;

//  // c = ix+someSize;


%>

<div>
</body>
</html>
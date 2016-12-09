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

enum week { sunday, monday, tuesday, wednesday, thursday, friday, saturday };

// int main()
// {
//     enum week today;
//     today = wednesday;
//     printf("Day %d",today+1);
//     return 0;
// }


//a->d[2].c =  arr[a->d[2].c];

// struct point *p = &my_point;
// struct point my_point = { 3, 7 };

// struct sockaddr_in serv_addr, cli_addr;
// struct MyStruct *secondArray;
//struct MyStruct myArray[4];
 float v3;

 int   someSize;
 int   ix;
 string x = "hola";

 int c = ix+x;

void add(struct distance d1,struct distance d2, struct distance *d3) 
{
     //Adding distances d1 and d2 and storing it in d3
     d3->feet = d1.feet + d2.feet; 
     d3->inch = d1.inch + d2.inch;

     if (d3->inch >= 12) {     /* if inch is greater or equal to 12, converting it to feet. */
         d3->inch -= 12;
         //++d3->feet;
    }
}

void copy_array(float *src, float *dst, int n)
{
    while (n-- > 0) {
 // Loop that counts down from n to zero
        *dst++ = *src++;   // Copies element *(src) to *(dst),
                           //  then increments both pointers
    }
}



char cha,nplname[20],c,plname[20];

int  i = 5, j = 6, k;

int myArray[10][2] = { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

 float A[6][8];
 float *pf;
 pf = &A[0][0];
 //*(pf+1) = 1.3;   /* assigns 1.3 to A[0][1] */
 //*(pf+8) = 2.3;   /* assigns 2.3 to A[1][0] */


  long  myArray[20];
 long  *pArray;
 int  i;


    int numbersAdded = 3.0;   
      int sum = 23.45;  
      int hex = 0x3F7; 
      int octal = 007; 
      int number = 78;
      int n = 23E-10;  
      int n2 = 23e-5;


float KrazyFunction( int *parm1, int p1size, int bb )
 {
   int ix; //declaring an integer variable//
   string y = false;
   for (ix=0; ix<p1size; ix++) {
      if (parm1[ix].m_aNumber == bb )
          return parm1[ix].num2;
   }
   return 0;
 }                   


 while( a.edad < 20 ) {
      printf("value of a: %d\n", *a);
      a++;
      const char x = 'x';  
       for (ix=0; ix<p1size; ix++) {
      if (parm1[ix].m_aNumber == bb )
          return parm1[ix].num2;
      }   
   }

//*a; 

a[i].edad = a+b;

++a;

//a++;

struct user//Structure for storing User information
    {
        char uid[4];
        char name[30] ,password[30][a];

    } user;

struct potNumber{
    //int x = 1;
    int x ;
    int array[20];
    char theName[10][20];
};

struct account {
   int account_number;
   char *first_name;
   char *last_name;
   float balance;
};

struct Books {
   char  title[50];
   char  author[50];
   char  subject[100];
   int   book_id;
} book;  


#include "stdio.h"


const char *x = 'x';      
  
if (((4 * 5) + 6  )/4) {     /* if inch is greater or equal to 12, converting it to feet. */
    //   d3->inch -= 12;
        //++d3->feet;
      #include "stdio.h"
      const char x = 'x';     
  }
  else
  
  const char grade = 'B';
   switch(grade) {
      case 'A' :
         printf("Excellent!\n" );
         break;
      case 'B' :
      case 'C' :
         printf("Well done\n" );
         break;
      case 'D' :
         printf("You passed\n" );
         break;
      case 'F' :
         printf("Better try again\n" );
         break;
      default :
         printf("Invalid grade\n" );
   }
  

enum suit {
  club = 0,
  diamonds = 10,
  hearts = 20,
  spades = 3,
  jimbo
};

   while( a.edad < 20 ) {
      printf("value of a: %d\n", a);
      a++;
      const char x = 'x';     
   }

    do {
      printf("value of a: %d\n", a);
      a = a + 1;
   }while(a>6);
 

    for( i = 0; i <= j; i ++ )
    {
       if( i == 5 )
       {
          continue;
       }
       printf("Hello %d\n", i );
    }

    return 0;

  struct coordinate{
    int x;
    int y;
    int direction;
};
 

  // score=(float)countr/countq*100-difftime(finaltime,initialtime)/3;


%>

<div>
</body>
</html>
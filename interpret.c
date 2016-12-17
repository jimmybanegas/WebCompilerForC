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

//string kds = 1 + 2;

//float kdx = 2 + 2.5;

// int num=212, tc;

//  int respuesta, respuesta2;

//      for (tc = 0; tc <= 2; ++tc){
//          respuesta = num >> tc ;
//          respuesta2 = num << tc;
//      }
      
//     int jc = 12, kc = 25;

//     int lc = jc & kc;

//      int llc = 12, mc = 25;
//      int nc = llc | mc;

//       int oc = 12, pc = 25;
//       int  qc = oc^pc;

//       int rc = ~35;
//       int sc = ~(-12);

// char ll = "hola";

//  int negativo = -1;

// int a = 20;

// char b = 'h';

// bool c = true;

// bool d;

// float normalizationFactor = 22.442e2;

// int uno = 0xF;
// int dos = 00001111;

// string hola = "hola mundo";

// date fecha = #14-04-1991#;

// int e, f=12, g = true, h;

// int i = 1 + 2;

// string j = "hola " + "mundo";

// string k = 'j'+'i';

// bool l = 0+1;

// int m = 6*5;

// int o = 10/5;

// float p = 20.5-6.5;

// int q = 10-6.5;

// bool r = p > q;

// bool s = p < q;

// int u ;
// bool ra ;

// if  (ra){ 
//     int t = 75;
//     u = t;
// }
// else{
//     u = 32;
// }
//  u++;
 
//    int v;
	
//    /* for loop execution */
//    for( v = 10; v < 20; v = v + 1 ){
//       u++;
//    }

//     for( v = 10; v < 20; v = v + 1 ){
//       u--;
//    }

//    int w = 0;

//    while (w < 5){

//        u += 10;
       
//        w++;
//    }

//     int x = 10;
//     int y;

//    /* do loop execution */
//    do {
//       x = x + 1;
//       y++;
//    }while( x < 20 );

//    const int aa = 20;

//    int ab = aa;

//    const char ac= 'j';

//    char ad = ac;
// bool af = false;

// bool ag = !af;


//     int ij, jk;

//     int ae;

//     string er;

//     while (ij <= 5)
//     {
//         jk=1;
//         while (jk <= ij )
//         {           
//             jk++;
//             er = er + "x";
//         }
//         ij++;
//     }

//     int i2=1,j2;
//     do
//     {
//         j2=1;
//         do
//         {
//            // printf("*");
//             j2++;
//         }while(j2 <= i2);
//         i2++;
//        // printf("\n");
//     }while(i2 <= 5);

//      int i3,j3,n = 20;
//      bool tr = true;

//     for(i3 = 7;i3 <= n;i3 ++)
//     {
//         for(j3=3;j3<=10;j3++)
//         {
//             if(tr)
//             {
//                 er = er + "jim-bob-rob";
//                 break;
//             }          
//         }

//         tr = false;    
//     }


//  int ic = 5, cc, dc, ec, fc,gc,hc;

//     cc = ic;
//     dc = cc;
   
//     cc += ic; // c = c+a
//     ec= cc;

//     cc -= ic; // c = c-a
//     fc = cc;
  
//     cc *= ic; // c = c*a
//     gc =cc;
  
//     cc /= ic; // c = c/a
//     hc=cc;

//     cc %= ic; // c = c%

//    int dos = 6 , tres = 6;

//    string cuatro;

//    if   (!(dos == tres)){
//        cuatro = "si funciona Rafa";
//    }



//   int num=212, i;
//     int respuesta = 0, respuesta2 =0;

//     for (i=0; i < 3; i++){
//          respuesta = num >> i;
//          respuesta2 = num << i;
//     }

  
//     int num2 = 10, count, sum = 0;


//     // for loop terminates when n is less than count
//     for(count = 1; count <= num2; ++count)
//     {
//         sum += count;
//     }

//      /* local variable definition */
   int a = 10, cont = 0 ;

   /* while loop execution */
   while( a < 20 ) {
      //cont++;
      a++;
		
      if( a > 15) {
         /* terminate the loop using break statement */
         cont++;
         break;
      }		
   }


//     /* local variable definition */
//    int aas = 10;

//    /* do loop execution */
//    do {
   
//       if( aas == 15) {
//          /* skip the iteration */
//          aas = aas + 1;
//          continue;
//       }
		
//       //printf("value of a: %d\n", a);
//       aas++;
     
//    } while( aas < 20 );


//     char operator = 'a';
//     int firstNumber = 10,secondNumber = 23;
//     int result;

//     switch(operator)
//     {
//         case '+':
//             result = firstNumber+secondNumber;
//             break;

//         case '-':
//              result = firstNumber-secondNumber;
//             break;

//         case '*':
//             result = firstNumber*secondNumber;
//             break;

//         case '/':
//              result = firstNumber/secondNumber;
//             break;
//         default:
//              result = 18061993;
//     }

//char cha,nplname[10], *ch , *plname[20] ;

//int mark[5] = {19, 10, 8, 17, 9};

// int x = mark[0];



// int mark2[3][2] = {19, 10, 8, 17, 9, 12};

// mark2[0][1] = 12;

// int c[2][3] = {1, 3, 0, -1, 5, 9};

// int dos = c[0][1];

int c[3][4]  = {0, 1, 2, 3,   /*  initializers for row indexed by 0 */
   4, 5, 6, 7 ,   /*  initializers for row indexed by 1 */
  8, 9, 10, 11   /*  initializers for row indexed by 2 */
};

int mark[5] = {19, 10, 8, 17, 9};

mark[0] = 12;


int x = -9 * 4;

int suma (int a, int b){
    return a+b;
}

int e = 3;
int d = 4;

int res = suma(e,d);

void displayNumbers(int num[2][2])
{
    // Instead of the above line,
    // void displayNumbers(int num[][2]) is also valid
    int i, j;
  //  printf("Displaying:\n");
    for (i = 0; i < 2; ++i){
        for (j = 0; j < 2; ++j){
            int mark5[5] = {19, 10, 8, 17, 9};
        }
    }
       
            //printf("%d\n", num[i][j]);
}

displayNumbers(mark);

%>

<div>
</body>
</html>
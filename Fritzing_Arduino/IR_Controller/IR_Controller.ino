#include <IRremote.h>

const int RECV_PIN = 7;
IRrecv irrecv(RECV_PIN);
decode_results results;
unsigned long key_value = 0;

void setup() {
  Serial.begin(9600);
  irrecv.enableIRIn();
  irrecv.blink13(true);
}

void loop() {
  if (irrecv.decode(&results)) {

    if (results.value == 0XFFFFFFFF)
      results.value = key_value;

    switch (results.value) {
      case 0xFFA25D:
        //Serial.write("CH-");
        Serial.println("CH-");
        break;
      case 0xFF629D:
        //Serial.write("CH");
        Serial.println("CH");
        break;
      case 0xFFE21D:
        //Serial.write("CH+");
        Serial.println("CH+");
        break;
      case 0xFF22DD:
        //Serial.write("|<<");
        Serial.println("|<<");
        break;
      case 0xFF02FD:
        //Serial.write(">>|");
        Serial.println(">>|");
        break ;
      case 0xFFC23D:
        //Serial.write(">|");
        Serial.println(">|");
        break ;
      case 0xFFE01F:
        //Serial.write("-");
        Serial.println("-");
        break ;
      case 0xFFA857:
        //Serial.write("+");
        Serial.println("+");
        break ;
      case 0xFF906F:
        //Serial.write("EQ");
        Serial.println("EQ");
        break ;
      case 0xFF6897:
        //Serial.write("0");
        Serial.println("0");
        break ;
      case 0xFF9867:
        //Serial.write("100+");
        Serial.println("100+");
        break ;
      case 0xFFB04F:
        //Serial.write("200+");
        Serial.println("200+");
        break ;
      case 0xFF30CF:
        //Serial.write("1");
        Serial.println("1");
        break ;
      case 0xFF18E7:
        //Serial.write("2");
        Serial.println("2");
        break ;
      case 0xFF7A85:
        //Serial.write("3");
        Serial.println("3");
        break ;
      case 0xFF10EF:
        //Serial.write("4");
        Serial.println("4");
        break ;
      case 0xFF38C7:
        //Serial.write("5");
        Serial.println("5");
        break ;
      case 0xFF5AA5:
        //Serial.write("6");
        Serial.println("6");
        break ;
      case 0xFF42BD:
        //Serial.write("7");
        Serial.println("7");
        break ;
      case 0xFF4AB5:
        //Serial.write("8");
        Serial.println("8");
        break ;
      case 0xFF52AD:
        //Serial.write("9");
        Serial.println("9");
        break ;
    }
    key_value = results.value;
    irrecv.resume();
  }
}

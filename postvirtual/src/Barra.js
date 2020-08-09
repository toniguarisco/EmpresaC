import React from 'react';
import {
  StyleSheet,
  Text,
  View,
  TouchableHighlight,
  Image
} from 'react-native';

const Barra = props =>{
		return(
			 <View style={styles.container}>
			 </View>
			)
  }

const styles = StyleSheet.create({
  container:{
 	flexDirection: "row",
 	height: 70,
 	alignItems: "center",
  justifyContent: "space-between",
 	paddingHorizontal: 15
  },
  image:{
    width: 120,
    height: 60
  }
})

export default Barra;
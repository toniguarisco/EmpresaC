import { Navigation } from "react-native-navigation";
import registerScreens from 'postvirtual/src/screens/registerScreens';
import setNavigationRoot from "./src/services/setNavigationRoot";

registerScreens();

const onRegisterAppLaunchedListener = async () => {
    setNavigationRoot();
};

Navigation.events().registerAppLaunchedListener(onRegisterAppLaunchedListener);
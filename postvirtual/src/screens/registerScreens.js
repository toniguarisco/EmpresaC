import { Navigation } from 'react-native-navigation';
import LoginFormScreen from '../Login';
import LoggedScreen from './First';

export default function registerScreens() {
    Navigation.registerComponent(
        'app.loginForm,
        ( ) => LoginF
    );

    Navigation.registerComponent(
        'app.logged,
        ( ) => First
    );
}

import React from 'react';
import { createMuiTheme } from "@material-ui/core";
import MuiThemeProvider from "@material-ui/core/styles/MuiThemeProvider";
import { connect } from 'react-redux';
import TodoAppBar from './components/TodoAppBar';
import TodoContent from './components/TodoContent';
import CssBaseline from '@material-ui/core/CssBaseline';

const theme = createMuiTheme({
  palette: {
    //type: "dark",
    //primary: blue,
    //secondary: deepPurple
  },
  typography: {
    useNextVariants: true,
  }
});

class App extends React.Component {
  render() {
    return (
      <MuiThemeProvider theme={theme}>
        <React.Fragment>
          <CssBaseline />
          <TodoAppBar />
        </React.Fragment>
        <TodoContent />
      </MuiThemeProvider>
    );
  };
}

function mapStateToProps(state) {
  const { alert } = state;
  return {
    alert
  };
}

const connectedApp = connect(mapStateToProps)(App);

export { connectedApp as App };
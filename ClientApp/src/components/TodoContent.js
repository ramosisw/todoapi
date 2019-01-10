import React from 'react';
import { connect } from 'react-redux';
import PropTypes from 'prop-types';
import { todoActions } from '../actions/todo.actions';
import TodoItemCard from '../components/TodoItemCard';

import { withStyles } from '@material-ui/core/styles';
import Grid from "@material-ui/core/Grid/Grid";

const styles = theme => ({
    root: {
        display: 'flex',
    },
    layout: {
        width: 'auto',
        marginLeft: theme.spacing.unit,
        marginRight: theme.spacing.unit,
        [theme.breakpoints.up(900 + theme.spacing.unit)]: {
            width: 900,
            marginLeft: 'auto',
            marginRight: 'auto',
        },
    },
    appBarSpacer: theme.mixins.toolbar,
});

class TodoContent extends React.Component {

    componentDidMount() {
        this.props.dispatch(todoActions.get());
    }

    render() {
        const { classes, data } = this.props;
        return (
            <main className={classes.layout}>
                <div className={classes.appBarSpacer} />
                <div className={classes.root}>
                    <Grid container spacing={24}>
                        {data && data.map(m => (
                            <Grid item md={4}>
                                <TodoItemCard todo={m} />
                            </Grid>)
                        )}
                    </Grid>
                </div>
            </main>
        )
    }
}

function mapStateToProps(state) {
    const { data } = state.todo.get;
    return {
        data
    };
}

TodoContent.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(connect(mapStateToProps)(TodoContent));
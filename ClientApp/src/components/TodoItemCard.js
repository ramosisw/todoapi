import React from 'react';
import PropTypes from 'prop-types';
import { withStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import Typography from '@material-ui/core/Typography';

const styles = {
    card: {
        minWidth: 275,
    },
    bullet: {
        display: 'inline-block',
        margin: '0 2px',
        transform: 'scale(0.8)',
    },
    title: {
        marginBottom: 16,
        fontSize: 14,
    },
    pos: {
        marginBottom: 12,
    },
};

function TodoItemCard(props) {
    const { classes, todo } = props;

    return (
        <Card className={classes.card}>
            <CardContent>
                <Typography variant="h5" component="h2">
                    {todo.name}
                </Typography>
                <Typography component="p">
                    {todo.details}
                </Typography>
                <Typography className={classes.pos} color="textSecondary">
                    {todo.startDate} - {todo.endDate}
                </Typography>
            </CardContent>
        </Card >
    );
}

TodoItemCard.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(TodoItemCard);
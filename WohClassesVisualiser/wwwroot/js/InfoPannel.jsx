class InfoPannel extends React.Component {

    constructor(props) {
        super(props);
        this.state = { type: "", data: "" };
    }

    render() {
        return <div id="InfoPannel" style={{ float: 'left', border: '3px solid #000', height: '726px', width: '300px' }}>
            <p>InfoPannel</p>
            <p>{this.props.type}</p>
            <p>{this.props.data}</p>
        </div>;
    }
}
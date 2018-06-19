class Application extends React.Component {
    constructor(props) {
        super(props);

        this.onHexClick = this.onHexClick.bind(this);

        this.state = { type: "", data: "" };
    }

    render() {
        return <div>
            <div style={{ position: 'relative', float: 'left', border: '3px solid #000', height: '726px', width: '826px', overflow: 'scroll' }}>
                <Battlefield apiUrl={document.getElementById("GetMapUrl").innerHTML} xMax="0" yMax="0" onhexclick={this.onHexClick} />
            </div>
            <InfoPannel type={this.state.type} data={this.state.data} />
        </div>;
    }

    onHexClick(newType, newData) {
        this.setState({ type: newType, data: newData });
    }
}

ReactDOM.render(
    <Application />,
    document.getElementById("BattlefieldFrame")
);
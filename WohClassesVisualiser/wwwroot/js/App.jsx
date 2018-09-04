class Application extends React.Component {

    constructor(props) {
        super(props);

        this.onHexClick = this.onHexClick.bind(this);

        this.state = { accountData: "", type: "", data: "" };
    }

    // загрузка данных
    loadPlayerData() {
        let xhr = new XMLHttpRequest();
        xhr.open("get", this.props.accountDataUrl, true);
        xhr.onload = function () {
            let data = JSON.parse(xhr.responseText);
            this.setState({ accountData: data });
        }.bind(this);
        xhr.send();
    }

    componentDidMount() {
        this.loadPlayerData();
    }

    render() {
        return <div>
            <div style={{ position: 'relative', float: 'left', border: '3px solid #000', height: '726px', width: '826px', overflow: 'scroll' }}>
                <Battlefield apiMapUrl={document.getElementById("GetMapUrl").innerHTML} xMax="0" yMax="0" onhexclick={this.onHexClick} />
            </div>
            <InfoPannel signoutUrl={document.getElementById("GetSignoutUrl").innerHTML} type={this.state.type} data={this.state.data} />
        </div>;
    }

    onHexClick(newType, newData) {
        this.setState({ type: newType, data: newData });
    }
}

ReactDOM.render(
    <Application accountDataUrl={document.getElementById("AccountDataUrl").innerHTML}/>,
    document.getElementById("BattlefieldFrame")
);
class Application extends React.Component {
    render() {
        //let url = document.getElementById("HomeControllerUrl").innerHTML;
        return <Battlefield apiUrl={document.getElementById("HomeControllerUrl").innerHTML} />;
    }
}

ReactDOM.render(
    <Application />,
    document.getElementById("BattlefieldFrame")
);
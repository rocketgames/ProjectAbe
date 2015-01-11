
var ECKey = bitcoin.ECKey;
var Address = bitcoin.Address;
var scripts = bitcoin.scripts;



function CreateMultiSig(bitcoinAddress) {


var BitcoinAddress1 = bitcoinAddress; //"1Fratqwo3Bu2FwMBzAex8WgDbmmGgJYLGH";
var BitcoinAddress2 = "112jFbM3Lp3qRSjezGFCv2rejT3UQ6rH5Z";

var addr1 =  Address.fromBase58Check(BitcoinAddress1);
var addr2 =  Address.fromBase58Check(BitcoinAddress2);

var branch1 = scripts.pubKeyHashOutput(addr1.hash);
var branch2 = scripts.pubKeyHashOutput(addr2.hash);

var branch_builder = new BranchingTransactionBuilder();
branch_builder.addSubScript(branch1);
branch_builder.addSubScript(branch2);
var branch_redeem_script = branch_builder.script();

var scriptPubKey = bitcoin.scripts.scriptHashOutput(branch_redeem_script.getHash())
var multisigAddress = bitcoin.Address.fromOutputScript(scriptPubKey).toString()
var redeemScript =  branch_redeem_script.buffer.toString('hex');

console.log("{");
console.log("MultiSigAddress:'" + multisigAddress + "',");
console.log("RedeemScript: '" + branch_redeem_script.buffer.toString('hex')+"'");
console.log("}");  
return new MultiSigReply(multisigAddress,redeemScript);
}         

function MultiSigReply(_address, _redeemScript) {
	var self=this;
	self.address = _address;
	self.redeemScript = _redeemScript;
}



// Make Transaction
function SignMultiBitTransaction(bitcoinAddress, BitcoinAmountToSend, tx_hash_big_endian) {
var Transaction = bitcoin.Transaction;
var TransactionBuilder = bitcoin.TransactionBuilder;

//var BitcoinToSendTo = myArgs[0];
//var BitcoinAmountToSend = myArgs[1];
//var tx_hash_big_endian =  myArgs[2];
var satoshiAMountToSend = BitcoinToSendTo * 100000000;
console.log(satoshiAMountToSend);
var addrToSendTo = Address.fromBase58Check(bitcoinAddress);
var branchToSendTo = scripts.pubKeyHashOutput(addrToSendTo.hash);

// Just repeating what's above to reiterate and segregate the code
BitcoinAddress2 = "112jFbM3Lp3qRSjezGFCv2rejT3UQ6rH5Z";
addr2 =  Address.fromBase58Check(BitcoinAddress2);
branch2 = scripts.pubKeyHashOutput(addr2.hash);

// Unspent amount: from https://blockchain.info/unspent?active=3PcxJeW5f6Tp4mVAXe4ggGRvDREAPCMF4o
            var test_output = {"unspent_outputs":[
                    {
                        "tx_hash":"3be8387e161bfc927cd4d06e4f1a800806ba509f74185709ee460967fe1d57c5",
                        "tx_hash_big_endian":"c5571dfe670946ee095718749f50ba0608801a4f6ed0d47c92fc1b167e38e83b",
                        "tx_index":74160687,
                        "tx_output_n": 0,
                        "script":"a914f08e151def9e83a2d96b44b5d87c719dcd374d8a87",
                        "value": 200000,
                        "value_hex": "030d40",
                        "confirmations":0
                    }
            ]};


var branch_redeem_script2 = branch_builder.script(branch_redeem_script.buffer.toString('hex'));
var spend_builder = new TransactionBuilder();
//spend_builder.addInput(test_output['unspent_outputs'][0]['tx_hash_big_endian'], 0);
//spend_builder.addOutput("1Dc8JwPsxxwHJ9zX1ERYo9q7NQA9SRLqbC", test_output['unspent_outputs'][0]['value'] - 10000);

spend_builder.addInput(tx_hash_big_endian, 0);
spend_builder.addOutput("1Dc8JwPsxxwHJ9zX1ERYo9q7NQA9SRLqbC", satoshiAMountToSend);


var priv2 = ECKey.fromWIF('L3MRgBTuEtfvEpwb4CcGtDm4s79fDR8UK1AhVYcDdRL4pRpsy686');
var gp_builder = new BranchingTransactionBuilder(spend_builder);

// input 0 of the tx, second branch of 2 (index 1)
gp_builder.selectInputBranch(0, 1, 2);
gp_builder.signBranch(0, priv2, branch_redeem_script2, null, branchToSendTo);
var tx = gp_builder.build();

console.log(tx.toHex());

return tx.toHex();
}

//*/            
